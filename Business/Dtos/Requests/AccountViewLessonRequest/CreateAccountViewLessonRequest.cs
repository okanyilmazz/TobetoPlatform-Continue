namespace Business.Dtos.Requests.AccountViewLessonRequest;

public class CreateAccountViewLessonRequest
{
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
