﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Estates;

public class Rooms: ResidentialEstate
{
    public int StoreyNumber { get; set; }
    public int RoomNumber { get; set; }
}
