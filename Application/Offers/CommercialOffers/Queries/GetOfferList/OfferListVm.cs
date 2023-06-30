using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList
{
    public class CommercialOfferListVm
    {
        public IList<CommercialOffer> Offers { get; set; }
    }
}
