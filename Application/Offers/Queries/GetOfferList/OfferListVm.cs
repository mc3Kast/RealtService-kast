using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class OfferListVm
    {
        public IList<Offer> Offers { get; set; }
    }
}
