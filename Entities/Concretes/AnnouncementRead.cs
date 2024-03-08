using Core.Entities;

namespace Entities.Concretes;

public class AnnouncementRead : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid AnnouncementId { get; set; }
    public Account Account { get; set; }
    public Announcement Announcement { get; set; }
}
