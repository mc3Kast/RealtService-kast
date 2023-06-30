using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList
{
    public class CommercialEstateListVm
    {
        public IList<CommercialEstate> Estates { get; set; }
    }
}
