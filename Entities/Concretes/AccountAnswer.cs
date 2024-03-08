using Core.Entities;

namespace Entities.Concretes;

public class AccountAnswer : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public Guid QuestionId { get; set; }
    public string GivenAnswer { get; set; }

    public Account Account { get; set; }
    public Exam Exam { get; set; }
    public Question Question { get; set; }
}
