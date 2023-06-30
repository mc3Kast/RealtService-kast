using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Commands.UpdateOffer
{
    public class UpdateCommercialOfferCommandHandler : IRequestHandler<UpdateCommercialOfferCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCommercialOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateCommercialOfferCommand request, CancellationToken cancellationToken)
        {
            IRepository<CommercialOffer> offerRepository = _unitOfWork.CommercialOffers;
            var entity = await offerRepository.FindAsync(request.Id);
            Console.WriteLine(entity is null);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            entity.Description = request.Description;
            entity.Name = request.Title;
            entity.Address = request.Address;
            entity.EditDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
