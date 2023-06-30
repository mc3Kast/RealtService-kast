using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateList
{
    public class EstateListVm
    {
        public IList<Estate> Estates { get; set; }
    }
}
