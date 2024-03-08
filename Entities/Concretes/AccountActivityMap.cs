using Core.Entities;

namespace Entities.Concretes;

public class AccountActivityMap : Entity<Guid>
{
    public Guid? AccountId { get; set; }
    public Guid? ActivityId { get; set; }

    public Account? Account { get; set; }
    public ActivityMap? ActivityMap { get; set; }
}

