using Core.Entities;

namespace Entities.Concretes;

public class ProductionCompany : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; }
}