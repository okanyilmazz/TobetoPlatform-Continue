using Core.Entities;

namespace Entities.Concretes;

public class Badge : Entity<Guid>
{
    public string ThumbnailPath { get; set; }
    public string Name { get; set; }

    public virtual ICollection<AccountBadge> AccountBadges { get; set; }
}