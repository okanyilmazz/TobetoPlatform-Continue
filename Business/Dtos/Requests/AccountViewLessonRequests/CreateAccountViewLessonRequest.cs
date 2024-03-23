namespace Business.Dtos.Requests.AccountViewLessonRequests;

public class CreateAccountViewLessonRequest
{
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
