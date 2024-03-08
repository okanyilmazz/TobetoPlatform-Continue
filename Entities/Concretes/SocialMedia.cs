using Core.Entities;

namespace Entities.Concretes;

public class SocialMedia : Entity<Guid>
{
    public string Name { get; set; }
    public string IconPath { get; set; }

    public virtual ICollection<AccountSocialMedia>? AccountSocialMedias { get; set; }
}