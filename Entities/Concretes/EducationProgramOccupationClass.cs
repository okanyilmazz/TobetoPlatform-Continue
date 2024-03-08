using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramOccupationClass : Entity<Guid>
{
    public Guid EducationProgramId { get; set; }
    public Guid OccupationClassId { get; set; }

    public EducationProgram EducationProgram { get; set; }
    public OccupationClass OccupationClass { get; set; }
}
