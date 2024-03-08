namespace Business.Dtos.Requests.EducationProgramSubjectRequests
{
    public class CreateEducationProgramSubjectRequest
    {
        public Guid EducationProgramId { get; set; }
        public Guid SubjectId { get; set; }
    }
}