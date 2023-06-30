using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList
{
    public class OfferLookupDto : IMapWith<CommercialOffer>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CommercialOffer, OfferLookupDto>()
                .ForMember(offerDto => offerDto.Id,
                    opt => opt.MapFrom(offer => offer.Id))
                .ForMember(offerDto => offerDto.Title,
                    opt => opt.MapFrom(offer => offer.Name));
        }
    }
}
