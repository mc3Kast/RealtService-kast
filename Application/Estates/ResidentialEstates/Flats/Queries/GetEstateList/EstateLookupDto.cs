using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList
{
    public class EstateLookupDto : IMapWith<Flat>
    {
        public int Id { get; set; }
        public float Square { get; set; }
        public int StoreyNumber { get; set; }
        public int RoomNumber { get; set; }
        public int WCNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flat, EstateLookupDto>()
                .ForMember(estateDto => estateDto.Id,
                    opt => opt.MapFrom(estate => estate.Id))
                .ForMember(estateDto => estateDto.StoreyNumber,
                    opt => opt.MapFrom(estate => estate.StoreyNumber))
                .ForMember(estateDto => estateDto.RoomNumber,
                    opt => opt.MapFrom(estate => estate.RoomNumber))
                .ForMember(estateDto => estateDto.WCNumber,
                    opt => opt.MapFrom(estate => estate.WCNumber))
                .ForMember(estateDto => estateDto.Square,
                    opt => opt.MapFrom(estate => estate.Square));
        }
    }
}
