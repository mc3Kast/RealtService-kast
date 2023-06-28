using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class OfferListVm
    {
        public IList<OfferLookupDto> Offers { get; set; }
    }
}
