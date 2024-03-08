using Core.Entities;

namespace Entities.Concretes;

public class CompetenceTestQuestion : Entity<Guid>
{
    public Guid CompetenceTestId { get; set; }
    public Guid CompetenceQuestionId { get; set; }

    public CompetenceTest CompetenceTest { get; set; }
    public CompetenceQuestion CompetenceQuestion { get; set; }
}
