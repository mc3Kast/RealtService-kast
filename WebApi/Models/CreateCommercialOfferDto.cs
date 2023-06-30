using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer;

namespace RealtService.WebApi.Models
{
    public class CreateCommercialOfferDto : IMapWith<CreateCommercialOfferCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCommercialOfferDto, CreateCommercialOfferCommand>()
                .ForMember(offerCommand => offerCommand.Name,
                    opt => opt.MapFrom(offerDto => offerDto.Title))
                .ForMember(offerCommand => offerCommand.Description,
                    opt => opt.MapFrom(offerDto => offerDto.Description))
                .ForMember(offerCommand => offerCommand.Address,
                    opt => opt.MapFrom(offerDto => offerDto.Address));
        }
    }
}
