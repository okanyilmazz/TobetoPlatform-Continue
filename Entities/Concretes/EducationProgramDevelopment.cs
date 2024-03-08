using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramDevelopment : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<EducationProgram> EducationPrograms { get; set; }

}
