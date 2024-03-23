namespace Business.Dtos.Requests.AccountViewLessonRequests;

public class UpdateAccountViewLessonRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
