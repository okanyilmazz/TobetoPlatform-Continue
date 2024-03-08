using Core.Entities;

namespace Entities.Concretes;

public class CompetenceCategory : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<CompetenceQuestion>? CompetenceQuestions { get; set; }
}