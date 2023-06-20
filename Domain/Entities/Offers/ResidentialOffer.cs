using RealtService.Domain.Entities.Estate;
using RealtService.Domain.Entities.Terms;

namespace RealtService.Domain.Entities.Offers;

public class ResidentialOffer: Offer
{
    public ResidentialEstate Estate { get; set; }
    public ResidentialTerm Term { get; set; }
}
