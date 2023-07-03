using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Users.Queries.GetUserList
{
    public class UserLookupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
