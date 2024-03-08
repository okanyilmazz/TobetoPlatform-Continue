using Core.Entities;

namespace Entities.Concretes;

public class OccupationClass : Entity<Guid>
{
    public string Name { get; set; }

    //public virtual ICollection<Homework>? Homeworks { get; set; }
    //public virtual ICollection<Session>? Sessions { get; set; }
    public virtual ICollection<EducationProgramOccupationClass>? EducationProgramOccupationClasses { get; set; }
    public virtual ICollection<ExamOccupationClass> ExamOccupationClasses { get; set; }
    public virtual ICollection<AccountOccupationClass> AccountOccupationClasses { get; set; }
    public virtual ICollection<OccupationClassSurvey>? OccupationClassSurveys { get; set; }
}
