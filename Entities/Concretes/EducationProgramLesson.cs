using Core.Entities;

namespace Entities.Concretes;

public class EducationProgramLesson : Entity<Guid>
{
    public Guid LessonId { get; set; }
    public Guid EducationProgramId { get; set; }

    public Lesson Lesson { get; set; }
    public EducationProgram EducationProgram { get; set; }
}