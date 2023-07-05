using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList
{
    public class CommercialEstateListVm
    {
        public IList<CommercialEstate> Estates { get; set; }
    }
}
