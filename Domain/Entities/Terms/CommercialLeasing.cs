using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Terms;

public class CommercialLeasing: CommercialTerm
{
    public decimal? PricePerMonth { get; set; }
    public decimal? PricePerYear { get; set; }
    public ICollection<CommercialLeasingRequirement> Requirements { get; set; }
}
