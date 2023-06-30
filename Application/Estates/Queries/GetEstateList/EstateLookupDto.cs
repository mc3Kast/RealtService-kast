using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateList
{
    public class EstateLookupDto : IMapWith<Estate>
    {
        public int Id { get; set; }
        public float Square { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Estate, EstateLookupDto>()
                .ForMember(estateDto => estateDto.Id,
                    opt => opt.MapFrom(estate => estate.Id))
                .ForMember(estateDto => estateDto.Square,
                    opt => opt.MapFrom(estate => estate.Square));
        }
    }
}
