using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Users;

public class UserBelongsToRole: IdentityUserRole<int>
{
    public virtual UserRole Role { get; set; }
    public virtual User User { get; set; }
}
