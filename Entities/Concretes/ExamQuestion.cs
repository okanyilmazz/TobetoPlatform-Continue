using Core.Entities;

namespace Entities.Concretes;

public class ExamQuestion : Entity<Guid>
{
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }

    public Question Question { get; set; }
    public Exam Exam { get; set; }
}