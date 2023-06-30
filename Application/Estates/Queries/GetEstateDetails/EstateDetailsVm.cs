using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities.Estates;

namespace RealtService.Application.Estates.Queries.GetEstateDetails
{
    public class EstateDetailsVm : IMapWith<Estate>
    {
        public int Id { get; set; }
        public float Square { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Estate, EstateDetailsVm>()
                .ForMember(estateVm => estateVm.Square,
                    opt => opt.MapFrom(offer => offer.Square))
                .ForMember(estateVm => estateVm.Id,
                    opt => opt.MapFrom(offer => offer.Id));
        }
    }
}
