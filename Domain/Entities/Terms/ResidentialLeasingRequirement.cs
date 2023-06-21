using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Terms;

public class ResidentialLeasingRequirement: NamedEntity
{
    public ICollection<ResidentialLeasing> Leasings { get; set; } = new List<ResidentialLeasing>();
}
