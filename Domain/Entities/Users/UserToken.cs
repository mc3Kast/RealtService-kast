using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Users;

public class UserToken: IdentityUserToken<int>
{
    public User User { get; set; }
}
