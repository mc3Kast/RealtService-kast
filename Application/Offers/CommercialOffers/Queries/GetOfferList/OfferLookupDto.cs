using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Offers;

namespace RealtService.Application.Offers.CommercialOffers.Queries.GetOfferList
{
    public class ComOfferLookupDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
