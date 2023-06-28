using MediatR;
using Microsoft.EntityFrameworkCore;
using RealtService.Application.Common.Exceptions;
using RealtService.Application.Interfaces;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Commands.UpdateOffer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, Unit>
    {
        private readonly IOfferDbContext _dbContext;

        public UpdateOfferCommandHandler(IOfferDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Offers.FirstOrDefaultAsync(offer => offer.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            {
                throw new NotFoundException(nameof(Offer), request.Id);
            }

           // entity.Description = request.Description;
            entity.Title = request.Title;
            entity.Address = request.Address;
            entity.EditTime = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
