using Core.Entities;

namespace Entities.Concretes;

public class DegreeType : Entity<Guid>
{
    public string Name { get; set; }
}
