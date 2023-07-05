using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Queries.GetEstateList
{
    public class ResidentialEstateListVm
    {
        public IList<ResidentialEstate> Estates { get; set; }
    }
}
