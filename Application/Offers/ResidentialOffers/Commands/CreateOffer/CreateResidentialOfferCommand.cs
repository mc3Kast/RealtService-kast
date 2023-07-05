using MediatR;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.ResidentialOffers.Commands.CreateOffer;

public record class CreateResidentialOfferCommand : IRequest<ResidentialOffer>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime PublicationDate { get; set; }
    public User User { get; set; }
    public ResidentialEstate Estate { get; set; }
    public ResidentialTerm Term { get; set; }
}
