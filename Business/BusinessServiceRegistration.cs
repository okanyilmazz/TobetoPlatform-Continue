using System.Reflection;
using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using Core.Business.Rules;
using Core.Utilities.Helpers;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Microsoft.Extensions.DependencyInjection;


namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<IActivityMapService, ActivityMapManager>();
        services.AddScoped<IAccountActivityMapService, AccountActivityMapManager>();
        services.AddScoped<IAccountAnswerService, AccountAnswerManager>();
        services.AddScoped<IAccountBadgeService, AccountBadgeManager>();
        services.AddScoped<IAccountHomeworkService, AccountHomeworkManager>();
        services.AddScoped<IAccountLanguageService, AccountLanguageManager>();
        services.AddScoped<IAccountLessonService, AccountLessonManager>();
        services.AddScoped<IAccountOccupationClassService, AccountOccupationClassManager>();
        services.AddScoped<IAccountSessionService, AccountSessionManager>();
        services.AddScoped<IAccountSkillService, AccountSkillManager>();
        services.AddScoped<IAccountSocialMediaService, AccountSocialMediaManager>();
        services.AddScoped<IAccountUniversityService, AccountUniversityManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementProjectService, AnnouncementProjectManager>();
        services.AddScoped<IBadgeService, BadgeManager>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<IDegreeTypeService, DegreeTypeManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<IEducationProgramService, EducationProgramManager>();
        services.AddScoped<IEducationProgramDevelopmentService, EducationProgramDevelopmentManager>();
        services.AddScoped<IEducationProgramLessonService, EducationProgramLessonManager>();
        services.AddScoped<IEducationProgramLevelService, EducationProgramLevelManager>();
        services.AddScoped<IEducationProgramOccupationClassService, EducationProgramOccupationClassManager>();
        services.AddScoped<IEducationProgramProgrammingLanguageService, EducationProgramProgrammingLanguageManager>();
        services.AddScoped<IEducationProgramSubjectService, EducationProgramSubjectManager>();
        services.AddScoped<IExamService, ExamManager>();
        services.AddScoped<IExamOccupationClassService, ExamOccupationClassManager>();
        services.AddScoped<IExamQuestionService, ExamQuestionManager>();
        services.AddScoped<IExamQuestionTypeService, ExamQuestionTypeManager>();
        services.AddScoped<IExamResultService, ExamResultManager>();
        services.AddScoped<IHomeworkService, HomeworkManager>();
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<ILanguageLevelService, LanguageLevelManager>();
        services.AddScoped<ILessonService, LessonManager>();
        services.AddScoped<ILessonCategoryService, LessonCategoryManager>();
        services.AddScoped<ILessonModuleService, LessonModuleManager>();
        services.AddScoped<ILessonSubTypeService, LessonSubTypeManager>();
        services.AddScoped<IMediaNewService, MediaNewManager>();
        services.AddScoped<IOccupationClassService, OccupationClassManager>();
        services.AddScoped<IOccupationClassSurveyService, OccupationClassSurveyManager>();
        services.AddScoped<IProductionCompanyService, ProductionCompanyManager>();
        services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageManager>();
        services.AddScoped<IProjectService, ProjectManager>();
        services.AddScoped<IQuestionService, QuestionManager>();
        services.AddScoped<IQuestionTypeService, QuestionTypeManager>();
        services.AddScoped<ISessionService, SessionManager>();
        services.AddScoped<ISkillService, SkillManager>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ISubjectService, SubjectManager>();
        services.AddScoped<ISurveyService, SurveyManager>();
        services.AddScoped<IUniversityService, UniversityManager>();
        services.AddScoped<IUniversityDepartmentService, UniversityDepartmentManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IWorkExperienceService, WorkExperienceManager>();
        services.AddScoped<IAccountEducationProgramService, AccountEducationProgramManager>();
        services.AddScoped<IOccupationService, OccupationManager>();
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IManagementProgramService, ManagementProgramManager>();
        services.AddScoped<ICompetenceCategoryService, CompetenceCategoryManager>();
        services.AddScoped<ICompetenceResultService, CompetenceResultManager>();
        services.AddScoped<ICompetenceQuestionService, CompetenceQuestionManager>();
        services.AddScoped<ICompetenceTestService, CompetenceTestManager>();
        services.AddScoped<ICompetenceTestQuestionService, CompetenceTestQuestionManager>();
        services.AddScoped<IAccountCompetenceTestService, AccountCompetenceTestManager>();
        services.AddScoped<IAccountViewLessonService, AccountViewLessonManager>();



        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IFileHelper, FileHelper>();
        services.AddScoped<ILessonLikeService, LessonLikeManager>();
        services.AddScoped<FileBusinessRules>();
        services.AddScoped<IAnnouncementTypeService, AnnouncementTypeManager>();
        services.AddScoped<IAnnouncementReadService, AnnouncementReadManager>();
        services.AddScoped<IMailService, MailManager>();



        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        return services;

    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}