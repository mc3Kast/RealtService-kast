using MediatR;

namespace RealtService.Application.Offers.Commands.CreateOffer
{
    public class CreateOfferCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public Guid CommercialOfferDatailsId { get; set; }
        public Guid ResidentialOfferDatailsId { get; set; }
        public Guid OfferTypeId { get; set; }
    }
}
