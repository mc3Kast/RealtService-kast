using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping (Profile profile)
        {
          profile.CreateMap<User, UserLookupDto>()
                .ForMember(userDto => Id,
                    opt => opt.MapFrom(user => user.Id))
                .ForMember(userDto => userDto.Name,
                    opt => opt.MapFrom(user => user.UserName));
        }
    }
}
