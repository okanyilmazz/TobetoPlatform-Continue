using Core.Entities;

namespace Entities.Concretes;

public class Session : Entity<Guid>
{
    public Guid LessonId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RecordPath { get; set; }

    public virtual ICollection<AccountSession>? AccountSessions { get; set; }
    public Lesson Lesson { get; set; }

}