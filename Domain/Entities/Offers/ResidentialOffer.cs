using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Domain.Entities.Offers;

public class ResidentialOffer: Offer
{
    public ResidentialEstate Estate { get; set; }
    public ResidentialTerm Term { get; set; }
}
