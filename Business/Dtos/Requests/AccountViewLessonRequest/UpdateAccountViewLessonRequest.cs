namespace Business.Dtos.Requests.AccountViewLessonRequest;

public class UpdateAccountViewLessonRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
