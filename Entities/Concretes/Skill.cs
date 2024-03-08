using Core.Entities;

namespace Entities.Concretes;

public class Skill : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<AccountSkill>? AccountSkills { get; set; }
}
