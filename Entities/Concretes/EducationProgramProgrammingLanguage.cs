using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramProgrammingLanguage : Entity<Guid>
{
    public Guid EducationProgramId { get; set; }
    public Guid ProgrammingLanguageId { get; set; }

    public EducationProgram EducationProgram { get; set; }
    public ProgrammingLanguage ProgrammingLanguage { get; set; }
}
