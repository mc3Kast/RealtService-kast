using RealtService.Domain.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Terms;

public abstract class CommercialTerm: Term
{
    public CommercialOffer Offer { get; set; }
    public int OfferId { get; set; }
}
