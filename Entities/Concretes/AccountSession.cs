using Core.Entities;

namespace Entities.Concretes;

public class AccountSession : Entity<Guid>
{
    public Guid SessionId { get; set; }
    public Guid AccountId { get; set; }
    public bool Status { get; set; }

    public Session Session { get; set; }
    public Account Account { get; set; }
}
