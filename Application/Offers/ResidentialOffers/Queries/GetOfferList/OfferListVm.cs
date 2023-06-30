using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList
{
    public class ResiadentialOfferListVm
    {
        public IList<ResidentialOffer> Offers { get; set; }
    }
}
