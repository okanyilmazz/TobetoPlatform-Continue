using Core.Entities;

namespace Entities.Concretes;

public class ExamResult : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public int CorrectOptionCount { get; set; }
    public int IncorrectOptionCount { get; set; }
    public int EmptyOptionCount { get; set; }
    public int Result { get; set; }

    public Account Account { get; set; }
    public Exam Exam { get; set; }
}