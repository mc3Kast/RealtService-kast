﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Users;

public class Agency : User
{
    public long? AgencyUniqueNumber { get; set; }
}
