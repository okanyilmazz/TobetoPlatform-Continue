using Core.Entities;

namespace Entities.Concretes;

public class LessonModule : Entity<Guid>
{
    public string Name { get; set; }
}
