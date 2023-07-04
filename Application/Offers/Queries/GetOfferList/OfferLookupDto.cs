using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;

namespace RealtService.Application.Offers.Queries.GetOfferList
{
    public class OfferLookupDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
