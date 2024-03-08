namespace Business.Dtos.Requests.EducationProgramProgrammingLanguageRequests
{
    public class CreateEducationProgramProgrammingLanguageRequest
    {
        public Guid EducationProgramId { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
    }
}