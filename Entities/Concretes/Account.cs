using Core.Entities;

namespace Entities.Concretes;

public class Account : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string? PhoneNumber { get; set; }
    public string? NationalId { get; set; }
    public string? Description { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? ProfilePhotoPath { get; set; }

    public User User { get; set; }

    public virtual ICollection<WorkExperience>? WorkExperiences { get; set; }
    public virtual ICollection<AccountOccupationClass>? AccountOccupationClasses { get; set; }
    public virtual ICollection<AccountSkill>? AccountSkills { get; set; }
    public virtual ICollection<Certificate>? Certificates { get; set; }
    public virtual ICollection<AccountSocialMedia>? AccountSocialMedias { get; set; }
    public virtual ICollection<AccountUniversity>? AccountUniversities { get; set; }
    public virtual ICollection<AccountLanguage>? AccountLanguages { get; set; }
    public virtual ICollection<AccountSession>? AccountSessions { get; set; }
    public virtual ICollection<AccountHomework>? AccountHomeworks { get; set; }
    public virtual ICollection<AccountLesson>? AccountLessons { get; set; }
    public virtual ICollection<AccountEducationProgram>? AccountEducationPrograms { get; set; }
    public virtual ICollection<AccountBadge>? AccountBadges { get; set; }
    public virtual ICollection<AccountActivityMap> ActivityMaps { get; set; }
    public virtual ICollection<LessonLike> LessonLikes { get; set; }
    public virtual ICollection<EducationProgramLike> EducationProgramLikes { get; set; }
    public virtual ICollection<AnnouncementRead> AnnouncementReads { get; set; }
}