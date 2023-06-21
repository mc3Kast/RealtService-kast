using RealtService.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Terms;

public class CommercialLeasingRequirement : NamedEntity
{
    public ICollection<CommercialLeasing> Leasings { get; set; } = new List<CommercialLeasing>();   
}
