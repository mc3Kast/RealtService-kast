using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Domain.Entities.Offers;

public class CommercialOffer: Offer
{
    public CommercialEstate Estate { get; set; }
    public CommercialTerm Term { get; set; }
}
