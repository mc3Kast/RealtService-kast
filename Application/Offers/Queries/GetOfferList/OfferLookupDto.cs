using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class OfferLookupDto : IMapWith<OfferTest>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<OfferTest, OfferLookupDto>()
                .ForMember(offerDto => offerDto.Id,
                    opt => opt.MapFrom(offer => offer.Id))
                .ForMember(offerDto => offerDto.Title,
                    opt => opt.MapFrom(offer => offer.Title));
        }
    }
}
