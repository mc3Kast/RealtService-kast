using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList
{
    public class CommercialEstateLookupDto : IMapWith<CommercialEstate>
    {
        public int Id { get; set; }
        public float Square { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommercialEstate, CommercialEstateLookupDto>()
                .ForMember(estateDto => estateDto.Id,
                    opt => opt.MapFrom(estate => estate.Id))
                .ForMember(estateDto => estateDto.Square,
                    opt => opt.MapFrom(estate => estate.Square));
        }
    }
}
