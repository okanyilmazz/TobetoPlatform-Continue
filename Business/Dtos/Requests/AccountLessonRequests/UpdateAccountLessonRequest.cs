namespace Business.Dtos.Requests.AccountLessonRequests;

public class UpdateAccountLessonRequest
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid AccountId { get; set; }
    public double StatusPercent { get; set; }
}
