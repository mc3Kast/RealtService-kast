using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat;

namespace RealtService.WebApi.Models
{
    public class CreateFlatDto : IMapWith<CreateFlatCommand>
    {
        public float Square { get; set; }
        public int StoreyNumber { get; set; }
        public int RoomNumber { get; set; }
        public int WCNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFlatDto, CreateFlatCommand>()
                .ForMember(flatCommand => flatCommand.Square,
                    opt => opt.MapFrom(flatDto => flatDto.Square))
                .ForMember(flatCommand => flatCommand.StoreyNumber,
                    opt => opt.MapFrom(flatDto => flatDto.StoreyNumber))
                .ForMember(flatCommand => flatCommand.RoomNumber,
                    opt => opt.MapFrom(flatDto => flatDto.RoomNumber))
                .ForMember(flatCommand => flatCommand.WCNumber,
                    opt => opt.MapFrom(flatDto => flatDto.WCNumber));
        }
    }
}
