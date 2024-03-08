using Core.Entities;

namespace Entities.Concretes;

public class QuestionType : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Question> Questions { get; set; }
}