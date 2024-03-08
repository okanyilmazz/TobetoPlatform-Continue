namespace Business.Dtos.Responses.EducationProgramLessonResponses;

public class GetEducationProgramLessonResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid EducationProgramId { get; set; }

    public string LessonName { get; set; }
    public string LessonSubTypeName { get; set; }

    public string EducationProgramName { get; set; }
    public double StatusPercent { get; set; }
}
