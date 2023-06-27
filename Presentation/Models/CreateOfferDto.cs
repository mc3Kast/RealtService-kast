/*using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.Commands.CreateOffer;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Domain.Entities;

namespace RealtService.Presentation.Models
{
    public class CreateOfferDto : IMapWith<CreateOfferCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateOfferDto, CreateOfferCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(offerDto => offerDto.Title))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(offerDto => offerDto.Description))
                .ForMember(noteCommand => noteCommand.Address,
                    opt => opt.MapFrom(offerDto => offerDto.Address));
        }
    }
}*/
