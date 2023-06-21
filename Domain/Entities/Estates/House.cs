using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Estates;

public class House : ResidentialEstate
{
    public int RoomNumber { get; set; }
    public int StroreyNumber { get; set; }
    public bool HasGarage { get; set; }
    public bool HasSwimmingPool { get; set; }
}
