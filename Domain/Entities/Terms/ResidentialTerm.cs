using RealtService.Domain.Entities.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Terms;

public abstract class ResidentialTerm: Term
{
    public ResidentialOffer Offer { get; set; }
}
