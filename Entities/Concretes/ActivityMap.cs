using Core.Entities;

namespace Entities.Concretes;

public class ActivityMap:Entity<Guid>
{
	public string Name { get; set; }
	public DateTime Date { get; set; }

	public virtual ICollection<AccountActivityMap> Accounts { get; set; }
}

