using Core.Entities;

namespace Entities.Concretes;

public class AccountSkill : Entity<Guid>
{
    public Guid SkillId { get; set; }
    public Guid AccountId { get; set; }

    public Account Account { get; set; }
    public Skill Skill { get; set; }
}