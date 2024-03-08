using Core.Entities;

namespace Entities.Concretes;

public class ProgrammingLanguage : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<EducationProgramProgrammingLanguage>? EducationProgramProgrammingLanguages { get; set; }
}