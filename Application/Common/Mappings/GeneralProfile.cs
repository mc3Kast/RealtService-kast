using AutoMapper;
using RealtService.Application.Estates.CommercialEstates.Queries.GetEstateList;
using RealtService.Application.Estates.Queries.GetEstateDetails;
using RealtService.Application.Estates.Queries.GetEstateList;
using RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat;
using RealtService.Application.Estates.ResidentialEstates.Flats.Queries.GetEstateList;
using RealtService.Application.Estates.ResidentialEstates.Queries.GetEstateList;
using RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList;
using RealtService.Application.Offers.Queries.GetOfferDetails;
using RealtService.Application.Offers.Queries.GetOfferList;
using RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;
using RealtService.Application.Offers.ResidentialOffers.Queries.GetOfferList;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Offer, OfferLookupDto>().ReverseMap();
            CreateMap<Offer, OfferDetailsVm>();
            CreateMap<ResidentialOffer, ResOfferLookupDto>();
            CreateMap<CommercialOffer, ComOfferLookupDto>();
            CreateMap<CreateCommercialOfferCommand, CommercialOffer>();
            CreateMap<CreateResidentialOfferCommand, ResidentialOffer>();
            CreateMap<Estate, EstateDetailsVm>();
            CreateMap<Estate, EstateLookupDto>().ReverseMap();
            CreateMap<ResidentialEstate, ResEstateLookupDto>();
            CreateMap<CommercialEstate, ComEstateLookupDto>();
            CreateMap<CreateFlatCommand, Flat>();
            CreateMap<Flat, FlatLookupDto>();
        }
    }
}
