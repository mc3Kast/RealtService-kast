using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Users.Queries.GetUserList
{
    public class UserListVm
    {
        public IList<User> Users { get; set; }
    }
}
