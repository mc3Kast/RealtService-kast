using MediatR;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Interfaces;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Commands.DeleteCommand
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand>
    {
        private readonly IOfferDbContext _dbContext;

        public DeleteOfferCommandHandler(IOfferDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Offers.FindAsync(new object[] { request.Id }, cancellationToken);
            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

            _dbContext.Offers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
