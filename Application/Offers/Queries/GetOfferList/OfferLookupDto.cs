using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class OfferLookupDto : IMapWith<Offer>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Offer, OfferLookupDto>()
                .ForMember(offerDto => offerDto.Id,
                    opt => opt.MapFrom(offer => offer.Id))
                .ForMember(offerDto => offerDto.Title,
                    opt => opt.MapFrom(offer => offer.Name));
        }
    }
}
