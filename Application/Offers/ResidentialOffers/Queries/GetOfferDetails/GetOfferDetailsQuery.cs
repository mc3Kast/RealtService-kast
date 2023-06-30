using MediatR;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferDetails
{
    public class GetOfferDetailsQuery : IRequest<OfferDetailsVm>
    {
        public int Id { get; set; }
    }
}
