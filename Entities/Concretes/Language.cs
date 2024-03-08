using Core.Entities;

namespace Entities.Concretes;

public class Language : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<AccountLanguage>? AccountLanguages { get; set; }
}