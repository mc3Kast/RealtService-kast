using MediatR;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.Queries.GetOfferDetails
{
    public class GetOfferDetailsQuery : IRequest<OfferDetailsVm>
    {
        public User UserId { get; set; }
        public int Id { get; set; }
    }
}
