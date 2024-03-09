using Core.Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts;

public class TobetoPlatformContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountAnswer> AccountAnswers { get; set; }
    public DbSet<AccountOccupationClass> AccountOccupationClasses { get; set; }
    public DbSet<AccountUniversity> AccountUniversities { get; set; }
    public DbSet<AccountLanguage> AccountLanguages { get; set; }
    public DbSet<AccountSession> AccountSessions { get; set; }
    public DbSet<AccountSkill> AccountSkills { get; set; }
    public DbSet<AccountHomework> AccountHomeworks { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<AnnouncementProject> AnnouncementProjects { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonCategory> LessonCategories { get; set; }
    public DbSet<EducationProgramLevel> EducationProgramLevels { get; set; }
    public DbSet<LessonSubType> LessonSubTypes { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<LessonModule> LessonModules { get; set; }
    public DbSet<EducationProgram> EducationPrograms { get; set; }
    public DbSet<DegreeType> DegreeTypes { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<EducationProgramProgrammingLanguage> EducationProgramProgrammingLanguages { get; set; }
    public DbSet<AccountLesson> AccountLessons { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<LanguageLevel> LanguageLevels { get; set; }
    public DbSet<MediaNew> MediaNews { get; set; }
    public DbSet<OccupationClass> OccupationClasses { get; set; }
    public DbSet<ProductionCompany> ProductionCompanies { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionType> QuestionTypes { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<EducationProgramLesson> EducationProgramLessons { get; set; }
    public DbSet<EducationProgramSubject> EducationProgramSubjects { get; set; }
    public DbSet<UniversityDepartment> UniversityDepartments { get; set; }
    public DbSet<ExamQuestionType> ExamQuestionTypes { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<EducationProgramOccupationClass> EducationProgramOccupationClasses { get; set; }
    public DbSet<OccupationClassSurvey> OccupationClassSurveys { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<ExamOccupationClass> ExamOccupationClasses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<ExamQuestion> ExamQuestions { get; set; }
    public DbSet<Occupation> Occupations { get; set; }
    public DbSet<EducationProgramDevelopment> EducationProgramDevelopments { get; set; }
    public DbSet<AccountBadge> AccountBadges { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<ManagementProgram> ManagementPrograms { get; set; }
    public DbSet<CompetenceCategory> CompetenceCategories { get; set; }
    public DbSet<CompetenceQuestion> CompetenceQuestions { get; set; }
    public DbSet<CompetenceResult> CompetenceResults { get; set; }
    public DbSet<CompetenceTest> CompetenceTests { get; set; }
    public DbSet<CompetenceTestQuestion> CompetenceTestQuestions { get; set; }
    public DbSet<ActivityMap> ActivityMaps { get; set; }
    public DbSet<AccountActivityMap> AccountActivityMaps { get; set; }
    public DbSet<LessonLike> LessonLikes { get; set; }
    public DbSet<EducationProgramLike> EducationProgramLikes { get; set; }
    public DbSet<AnnouncementType> AnnouncementTypes { get; set; }
    public DbSet<AnnouncementRead> AnnouncementReads { get; set; }
    public DbSet<AccountViewLesson> AccountViewLessons { get; set; }




    public TobetoPlatformContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}