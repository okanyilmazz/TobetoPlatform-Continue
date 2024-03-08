using Core.Entities;

namespace Entities.Concretes;

public class AnnouncementType : Entity<Guid>
{
    public string Name { get; set; }
}
