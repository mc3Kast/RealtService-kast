using MediatR;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateResidentialOfferCommand, ResidentialOffer>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResidentialOffer> Handle(CreateResidentialOfferCommand request, CancellationToken cancellationToken)
        {
           var offer = new ResidentialOffer
            {
                User = request.User,
                Name = request.Name,
                Description = request.Description,
                Address = request.Address,
                PublicationDate = DateTime.Now,
                EditDate = null
            };
            IRepository<ResidentialOffer> repository = _unitOfWork.ResidentialOffers;
            offer = repository.Insert(offer);
            await _unitOfWork.SaveChangesAsync();
            return offer;
        }
    }
}
