using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserRole : NamedEntity
{
    public static readonly UserRole USER = new UserRole() 
    { 
        Id = 1,
        Name = "USER"
    };

    public static readonly UserRole ADMIN = new UserRole()
    {
        Id = 2,
        Name = "ADMIN"
    };

    public ICollection<User> Users { get; set; } = new LinkedList<User>();
}
