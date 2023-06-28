using MediatR;

namespace RealtService.Application.Offers.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, Guid>
    {
        //    private readonly IOfferDbContext _dbContext;
        //    public async Task<Guid> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        //    {
        //        var offer = new OfferTest
        //        {
        //            UserId = request.UserId,
        //            Title = request.Title,
        //            Description = request.Description,
        //            Address = request.Address,
        //            CommercialOfferDatailsId = request.CommercialOfferDatailsId,
        //            ResidentialOfferDatailsId = request.ResidentialOfferDatailsId,
        //            OfferTypeId = request.OfferTypeId,
        //            Id = Guid.NewGuid(),
        //            PublicationTime = DateTime.Now,
        //            EditTime = null
        //        };

        //        await _dbContext.Offers.AddAsync(offer, cancellationToken);
        //        await _dbContext.SaveChangesAsync(cancellationToken);

        //        return offer.Id;
        //    }
        public Task<Guid> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
