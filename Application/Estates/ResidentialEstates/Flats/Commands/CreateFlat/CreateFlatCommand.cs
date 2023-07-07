using MediatR;
using RealtService.Domain.Entities.Estates;
using RealtService.Domain.Entities.Offers;
using RealtService.Domain.Entities.Terms;
using RealtService.Domain.Entities.Users;

namespace RealtService.Application.Estates.ResidentialEstates.Flats.Commands.CreateFlat;

public record class CreateFlatCommand : IRequest<Flat>
{
    //ResidentialOffer Offer { get; set; }
    public int OfferId { get; set; }
    public float Square { get; set; }
    public int StoreyNumber { get; set; }
    public int RoomNumber { get; set; }
    public int WCNumber { get; set; }
}
