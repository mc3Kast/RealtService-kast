using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Estates.ResidentialEstates.Queries.GetEstateList
{
    public class ResidentialEstateListVm
    {
        public IList<ResidentialEstate> Estates { get; set; }
    }
}
