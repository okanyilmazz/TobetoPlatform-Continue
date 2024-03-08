using Core.Entities;

namespace Entities.Concretes;

public class AccountCompetenceTest : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid CompetenceTestId { get; set; }
    
    public Account Account{ get; set; }
    public CompetenceTest CompetenceTest { get; set; }
}
