using MediatR;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.CommercialOffers.Commands.CreateOffer
{
    public class CreateCommercialOfferCommand : IRequest<CommercialOffer>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime PublicationDate { get; set; }
        public User User { get; set; }
        public CommercialEstate Estate { get; set; }
        public CommercialTerm Term { get; set; }
    }
}
