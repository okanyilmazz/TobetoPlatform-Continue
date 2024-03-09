using Core.Entities;

namespace Entities.Concretes;

public class AccountViewLesson : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }

    public Account Account { get; set; }
    public Lesson Lesson { get; set; }
}
