using Core.Entities;

namespace Entities.Concretes;

public class LessonSubType : Entity<Guid>
{
    public string Name { get; set; }
}
