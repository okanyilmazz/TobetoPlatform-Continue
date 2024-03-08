using Core.Entities;

namespace Entities.Concretes;

public class University : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<AccountUniversity>? AccountUniversities { get; set; }
}
