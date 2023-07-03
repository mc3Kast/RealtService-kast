using RealtService.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Users;

public class UserStatus: NamedEntity
{
    public virtual ICollection<User> Users { get; set; }
}
