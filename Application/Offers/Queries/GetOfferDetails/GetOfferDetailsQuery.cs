using MediatR;

namespace RealtService.Application.Offers.Queries.GetOfferDetails
{
    public class GetOfferDetailsQuery : IRequest<OfferDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
