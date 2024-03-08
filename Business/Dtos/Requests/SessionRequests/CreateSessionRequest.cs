namespace Business.Dtos.Requests.SessionRequests;

public class CreateSessionRequest
{
    public Guid LessonId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RecordPath { get; set; }

}