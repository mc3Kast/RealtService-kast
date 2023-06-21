using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferDetails
{
    public class OfferDetailsVm : IMapWith<Offer>
    {
        public Guid Id { get; set; }
        public DateTime PublicationTime { get; set; }
        public DateTime? EditTime { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<Offer, OfferDetailsVm>()
                .ForMember(offerVm => offerVm.Title,
                    opt => opt.MapFrom(offer => offer.Title))
            //    .ForMember(offerVm => offerVm.Description,
              //      opt => opt.MapFrom(offer => offer.Description))
                .ForMember(offerVm => offerVm.Id,
                    opt => opt.MapFrom(offer => offer.Id))
                .ForMember(offerVm => offerVm.PublicationTime,
                    opt => opt.MapFrom(offer => offer.PublicationTime))
                .ForMember(offerVm => offerVm.EditTime,
                    opt => opt.MapFrom(offer => offer.EditTime))
                .ForMember(offerVm => offerVm.Address,
                    opt => opt.MapFrom(offer => offer.Address));
        }
    }
}
