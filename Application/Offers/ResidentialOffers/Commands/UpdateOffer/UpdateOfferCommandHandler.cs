using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            IRepository<Offer> offerRepository = _unitOfWork.Offers;
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
