/*using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Application.Offers.Commands.UpdateOffer;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Domain.Entities;

namespace RealtService.Presentation.Models
{
    public class UpdateOfferDto : IMapWith<UpdateOfferCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateOfferDto, UpdateOfferCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(offerDto => offerDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(offerDto => offerDto.Title))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(offerDto => offerDto.Description))
                .ForMember(noteCommand => noteCommand.Address,
                    opt => opt.MapFrom(offerDto => offerDto.Address));
        }
    }
}*/
