namespace Business.Dtos.Requests.LessonLikeRequests;

public class UpdateLessonLikeRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
