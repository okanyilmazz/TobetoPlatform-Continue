using Core.Entities;

namespace Entities.Concretes;

public class LessonCategory : Entity<Guid>
{
    public string Name { get; set; }
}
