using MediatR;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer
{
    public class CreateCommercialOfferCommandHandler : IRequestHandler<CreateCommercialOfferCommand, CommercialOffer>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommercialOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CommercialOffer> Handle(CreateCommercialOfferCommand request, CancellationToken cancellationToken)
        {
            var offer = new CommercialOffer
            {
                User = null,
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                PublicationDate = DateTime.Now,
                Estate = null,
                Term = null,
                EditDate = null
            };
            IRepository<CommercialOffer> repository = _unitOfWork.CommercialOffers;
            offer = repository.Insert(offer);
            await _unitOfWork.SaveChangesAsync();
            return offer;
        }
    }
}
