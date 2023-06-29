using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserRole : NamedEntity
{
    public static readonly UserRole USER = new UserRole() 
    { 
        Name = "USER"
    };

    public static readonly UserRole ADMIN = new UserRole()
    {
        Name = "ADMIN"
    };

    public ICollection<User> Users { get; set; } = new LinkedList<User>();
}
