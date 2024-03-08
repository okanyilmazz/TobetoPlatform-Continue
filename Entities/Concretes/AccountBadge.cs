using Core.Entities;

namespace Entities.Concretes;

public class AccountBadge : Entity<Guid>
{
    public Guid? AccountId { get; set; }
    public Guid? BadgeId { get; set; }

    public Account? Account { get; set; }
    public Badge? Badge { get; set; }
}