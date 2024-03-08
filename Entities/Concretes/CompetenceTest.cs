using Core.Entities;

namespace Entities.Concretes;

public class CompetenceTest:Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuestionCount { get; set; }

    public virtual ICollection<CompetenceTestQuestion> CompetenceTestQuestions { get; set; }
    public virtual ICollection<AccountCompetenceTest> AccountCompetenceTests { get; set; }
}
