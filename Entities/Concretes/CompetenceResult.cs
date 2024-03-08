using Core.Entities;

namespace Entities.Concretes;

public class CompetenceResult : Entity<Guid>
{
    public Guid? CompetenceCategoryId { get; set; }
    public Guid? AccountId { get; set; }
    public double Point { get; set; }

    public CompetenceCategory? CompetenceCategory { get; set; }
    public Account? Account { get; set; }
}