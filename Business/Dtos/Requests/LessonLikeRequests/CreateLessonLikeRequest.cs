namespace Business.Dtos.Requests.LessonLikeRequests;

public class CreateLessonLikeRequest
{
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
