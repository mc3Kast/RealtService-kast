using RealtService.Domain.Entities.Estate;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Domain.Entities.Offers;

public class CommercialOffer: Offer
{
    public CommercialEstate Estate { get; set; }
    public CommercialTerm Term { get; set; }
}
