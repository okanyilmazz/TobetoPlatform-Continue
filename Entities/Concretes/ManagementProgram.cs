using Core.Entities;

namespace Entities.Concretes;

public class ManagementProgram:Entity<Guid>
{
    public string Name { get; set; }
}
