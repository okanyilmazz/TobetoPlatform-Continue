using Core.Entities;

namespace Entities.Concretes;

public class CompetenceQuestion : Entity<Guid>
{
    public Guid CompetenceCategoryId { get; set; }
    public string Description { get; set; }
    public int MaxOption { get; set; }


    public CompetenceCategory CompetenceCategory { get; set; }
    public virtual ICollection<CompetenceTestQuestion> CompetenceTestQuestions { get; set; }
}
