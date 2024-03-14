using Core.Entities;

namespace Entities.Concretes;

public class AccountEducationProgram : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
    public double? StatusPercent { get; set; }
    public int? TimeSpent { get; set; }


    public Account Account { get; set; }
    public EducationProgram EducationProgram { get; set; }
}
