using RealtService.Domain.Entities.Estates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList
{
    public class FlatListVm
    {
        public IList<Flat> Estates { get; set; }
    }
}
