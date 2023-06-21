using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Estates;

public class Warehouse: CommercialEstate
{
    public float CeilingHeight { get; set; }
    public bool HasClimateControl { get; set; }
}
