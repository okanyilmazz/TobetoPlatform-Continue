using Core.Entities;

namespace Entities.Concretes;

public class LanguageLevel : Entity<Guid>
{
    public string Name { get; set; }
}