using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.UnitOfWork;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.DeleteCommand
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteOfferCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            IRepository<Offer> offerRepository = _unitOfWork.Offers;
            var entity = await offerRepository.FindAsync(request.Id, cancellationToken);
            if (entity == null || entity.User != request.UserId)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            offerRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return Unit.Value;
        }

    }
}
