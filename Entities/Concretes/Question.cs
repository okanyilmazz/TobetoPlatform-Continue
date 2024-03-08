using Core.Entities;

namespace Entities.Concretes;

public class Question : Entity<Guid>
{
    public Guid QuestionTypeId { get; set; }
    public string Description { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string CorrectOption { get; set; }

    public QuestionType QuestionType { get; set; }
    public ICollection<ExamQuestion>? ExamQuestions { get; set; }
}