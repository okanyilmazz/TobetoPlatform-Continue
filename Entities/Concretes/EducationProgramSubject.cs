using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramSubject : Entity<Guid>
{
    public Guid EducationProgramId { get; set; }
    public Guid SubjectId { get; set; }

    public Subject Subject { get; set; }
    public EducationProgram EducationProgram { get; set; }

}
