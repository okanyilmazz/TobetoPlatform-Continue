using Core.Entities;

namespace Entities.Concretes;

public class AccountHomework : Entity<Guid>
{
    public Guid HomeworkId { get; set; }
    public Guid AccountId { get; set; }
    public bool Status { get; set; }
    public string FilePath { get; set; }

    public Homework? Homework { get; set; }
    public Account? Account{ get; set; }
}
