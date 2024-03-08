namespace Business.Dtos.Responses.LessonResponses;

public class GetLessonResponse
{
    public Guid Id { get; set; }
    public string LanguageName { get; set; }
    public string LessonModuleName { get; set; }
    public string LessonCategoryName { get; set; }
    public string LessonSubTypeName { get; set; }
    public string ProductionCompanyName { get; set; }
    public string Name { get; set; }
    public string LessonPath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
    public Guid LanguageId { get; set; }
    public Guid LessonModuleId { get; set; }
    public Guid LessonCategoryId { get; set; }
    public Guid LessonSubTypeId { get; set; }
    public Guid ProductionCompanyId { get; set; }
}
