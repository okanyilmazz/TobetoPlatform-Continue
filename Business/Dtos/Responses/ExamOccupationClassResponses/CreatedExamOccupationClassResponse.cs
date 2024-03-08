namespace Business.Dtos.Responses.ExamOccupationClassResponses;

public class CreatedExamOccupationClassResponse
{
    public Guid Id { get; set; }
    public Guid ExamId { get; set; }
    public Guid OccupationClassId { get; set; }
}
