using RealtService.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Domain.Entities.Users;

public abstract class User : NamedEntity
{
    public string Email { get; set; }
    public string HashPassword { get; set; }
    public DateTime RegistrationDate { get; set; }
    public ICollection<UserRole> Roles { get; set; } = new HashSet<UserRole>();
    public UserStatus Status { get; set; }
    public ICollection<UserContact> Contacts { get; set; } = new List<UserContact>();
}