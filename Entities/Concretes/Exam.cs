using Core.Entities;

namespace Entities.Concretes;


public class Exam : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }

    public virtual ICollection<ExamQuestion> ExamQuestions { get; set; }
    public virtual ICollection<ExamOccupationClass> ExamOccupationClasses { get; set; }
}