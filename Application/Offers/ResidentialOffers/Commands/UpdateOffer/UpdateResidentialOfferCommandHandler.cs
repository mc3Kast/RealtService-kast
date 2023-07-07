using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Common.UnitOfWork;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer
{
    public class UpdateResidentialOfferCommandHandler : IRequestHandler<UpdateResidentialOfferCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateResidentialOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateResidentialOfferCommand request, CancellationToken cancellationToken)
        {
            IRepository<ResidentialOffer> offerRepository = _unitOfWork.ResidentialOffers;
            var entity = await offerRepository.FindAsync(request.Id);
            Console.WriteLine(entity is null);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            entity.Description = request.Description;
            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.EditDate = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
