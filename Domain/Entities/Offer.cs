using System;

namespace RealtService.Domain.Entities
{
    public class Offer
    {
        public Guid UserId { get; set; }
        public Guid OfferTypeId { get; set; }
        public Guid CommercialOfferDatailsId { get; set; }
        public Guid ResidentialOfferDatailsId { get; set; }
        public Guid Id { get; set; }
        public DateTime PublicationTime { get; set; }
        public DateTime? EditTime { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }

    }
}
