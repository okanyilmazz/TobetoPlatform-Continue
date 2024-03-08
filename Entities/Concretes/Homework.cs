using Core.Entities;

namespace Entities.Concretes;

public class Homework : Entity<Guid>
{
    public Guid LessonId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }

    public Lesson Lesson { get; set; }
    public virtual ICollection<AccountHomework>? AccountHomeworks { get; set; }
}
