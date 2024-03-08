using Core.Entities;

namespace Entities.Concretes;

public class AccountLanguage : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid LanguageId { get; set; }
    public Guid LanguageLevelId { get; set; }

    public Account? Account { get; set; }
    public Language? Language{ get; set; }
    public LanguageLevel? LanguageLevel{ get; set; }
}