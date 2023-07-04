using AutoMapper;
using RealtService.Application.Common.Mappings;
using RealtService.Domain.Entities;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.Queries.GetOfferDetails
{
    public class OfferDetailsVm 
    {
        public int Id { get; set; }
        public DateTime PublicationTime { get; set; }
        public DateTime? EditTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public User User { get; set; }
    }
}
