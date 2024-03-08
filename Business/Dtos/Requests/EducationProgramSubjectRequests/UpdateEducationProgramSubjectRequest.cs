namespace Business.Dtos.Requests.EducationProgramSubjectRequests;

public class UpdateEducationProgramSubjectRequest
{
    public Guid Id { get; set; }
    public Guid EducationProgramId { get; set; }
    public Guid SubjectId { get; set; }
}