using RealtService.Domain.Entities.Base;
using RealtService.Domain.Entities.Users;

namespace RealtService.Domain.Entities;

public abstract class Offer : NamedEntity
{
    public string? Description { get; set; }
    public DateTime PublicationDate { get; set; }
    public string Address { get; set; }
    public DateTime? EditDate { get; set; }
    public User User { get; set; }
}
