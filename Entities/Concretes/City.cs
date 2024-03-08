using Core.Entities;

namespace Entities.Concretes;

public class City : Entity<Guid>
{
    public Guid CountryId { get; set; }
    public string Name { get; set; }

    public Country Country { get; set; }
    public virtual ICollection<District>? Districts { get; set; }
}
