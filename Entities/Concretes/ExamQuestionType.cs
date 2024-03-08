using Core.Entities;

namespace Entities.Concretes;

public class ExamQuestionType : Entity<Guid>
{
    public Guid QuestionTypeId { get; set; }
    public Guid ExamId { get; set; }

    public Exam Exam { get; set; }
    public QuestionType QuestionType { get; set; }
}
