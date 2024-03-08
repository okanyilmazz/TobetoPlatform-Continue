namespace Business.Dtos.Responses.SessionResponses;

public class UpdatedSessionResponse
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid LessonId { get; set; }
    public string RecordPath { get; set; }
}