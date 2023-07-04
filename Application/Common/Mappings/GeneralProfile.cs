using AutoMapper;
using RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.CommercialOffers.Commands.UpdateOffer;
using RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Offer, OfferLookupDto>().ReverseMap();
            CreateMap<ResidentialOffer, ResOfferLookupDto>();
            CreateMap<Offer, OfferDetailsVm>();
            CreateMap<CommercialOffer, ComOfferLookupDto>();
        }
    }
}
