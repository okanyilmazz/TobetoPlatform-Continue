namespace Business.Dtos.Requests.FilterRequest;

public class EducationProgramFilterRequest
{
    public Guid? RequestingAccountId { get; set; }
    public Guid? EducationProgramLevelId { get; set; }
    public Guid? SubjectId { get; set; }
    public Guid? ProgrammingLanguageId { get; set; }
    public Guid? EducationProgramDevelopmentId { get; set; }
    public Guid? AccountId { get; set; }

    public int CompleteStatus { get; set; }
    public bool SpecialForMe { get; set; }
    public int Paid { get; set; }
}
