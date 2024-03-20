using Core.Entities;

namespace Entities.Concretes;

public class Lesson : Entity<Guid>
{
    public Guid LanguageId { get; set; }
    public Guid LessonModuleId { get; set; }
    public Guid LessonCategoryId { get; set; }
    public Guid LessonSubTypeId { get; set; }
    public Guid ProductionCompanyId { get; set; }
    public string Name { get; set; }
    public string? LessonPath { get; set; }
    public string? ThumbnailPath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }

    public LessonModule LessonModule { get; set; }
    public LessonCategory LessonCategory { get; set; }
    public LessonSubType LessonSubType { get; set; }
    public ProductionCompany ProductionCompany { get; set; }
    public Language Language { get; set; }
    public virtual ICollection<EducationProgramLesson> EducationProgramLessons { get; set; }
    public virtual ICollection<AccountLesson>? AccountLessons { get; set; }
    public virtual ICollection<LessonLike>? LessonLikes { get; set; }
    public virtual ICollection<Session>? Sessions { get; set; }
    public virtual ICollection<Homework>? Homeworks { get; set; }
    public virtual ICollection<AccountViewLesson>? AccountViewLessons { get; set; }

}