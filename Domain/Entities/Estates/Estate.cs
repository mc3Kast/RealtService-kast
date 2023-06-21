using RealtService.Domain.Entities.Base;

namespace RealtService.Domain.Entities.Estates;

public abstract class Estate : Entity
{
    public float Square { get; set; }
}
