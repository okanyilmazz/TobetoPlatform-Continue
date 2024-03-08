using Core.Entities;

namespace Entities.Concretes;

public class Occupation : Entity<Guid>
{
    public string Name { get; set; }
}
