using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Terms;

public class ResidentialLeasing: ResidentialTerm
{
    public decimal? PricePerDay { get; set; }
    public decimal? PricePerMonth { get; set; }
    public decimal? PricePerYear { get; set; }
    public bool AllowedGirls { get; set; }
    public bool AllowedBoys { get; set; }
    public bool AllowedAlcohol { get; set; }
    public bool AllowedPets { get; set; }
}
