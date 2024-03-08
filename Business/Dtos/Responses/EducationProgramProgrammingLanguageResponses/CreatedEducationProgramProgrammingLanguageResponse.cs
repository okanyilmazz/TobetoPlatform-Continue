namespace Business.Dtos.Responses.EducationProgramProgrammingLanguageResponses
{
    public class CreatedEducationProgramProgrammingLanguageResponse
    {
        public Guid Id { get; set; }
        public Guid EducationProgramId { get; set; }
        public Guid ProgrammingLanguageId { get; set; }
    }
}