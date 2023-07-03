using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Users;

public class RoleClaim: IdentityRoleClaim<int>
{
    public UserRole Role { get; set; }
}
