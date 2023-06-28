using MediatR;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Offers.Commands.CreateOffer;

//Just Schema, Synch with Enterprise logic
public class CreateOfferCommand : IRequest<ResidentialOffer>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public User User { get; set; }
}
