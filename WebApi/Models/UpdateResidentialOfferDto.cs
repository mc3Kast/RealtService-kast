using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.ResidentialOffers.Commands.UpdateOffer;

namespace RealtService.WebApi.Models
{
    public class UpdateResidentialOfferDto : IMapWith<UpdateOfferCommand>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateResidentialOfferDto, UpdateOfferCommand>()
                .ForMember(offerCommand => offerCommand.Id,
                    opt => opt.MapFrom(offerDto => offerDto.Id))
                .ForMember(offerCommand => offerCommand.Title,
                    opt => opt.MapFrom(offerDto => offerDto.Title))
                .ForMember(offerCommand => offerCommand.Description,
                    opt => opt.MapFrom(offerDto => offerDto.Description))
                .ForMember(offerCommand => offerCommand.Address,
                    opt => opt.MapFrom(offerDto => offerDto.Address));
        }
    }
}
