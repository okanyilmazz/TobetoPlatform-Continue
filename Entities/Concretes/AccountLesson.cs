using Core.Entities;

namespace Entities.Concretes;

public class AccountLesson : Entity<Guid>
{
    public Guid LessonId { get; set; }
    public Guid AccountId { get; set; }
    public double StatusPercent { get; set; }

    public Lesson Lesson { get; set; }
    public Account Account { get; set; }
}
