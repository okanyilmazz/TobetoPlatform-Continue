using Core.Entities;

namespace Entities.Concretes;

public class Subject : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<EducationProgramSubject> EducationProgramSubjects { get; set; }
}
