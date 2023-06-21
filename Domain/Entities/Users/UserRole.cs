using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Users;

public class UserRole : NamedEntity
{
    public ICollection<User> Users { get; set; } = new LinkedList<User>();
}
