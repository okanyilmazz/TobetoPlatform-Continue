using Core.Entities;

namespace Entities.Concretes;

public class ExamOccupationClass : Entity<Guid>
{
    public Guid ExamId { get; set; }
    public Guid OccupationClassId { get; set; }

    public Exam Exam { get; set; }
    public OccupationClass OccupationClass { get; set; }
}

