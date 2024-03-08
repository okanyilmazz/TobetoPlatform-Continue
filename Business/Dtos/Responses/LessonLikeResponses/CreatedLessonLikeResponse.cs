namespace Business.Dtos.Responses.LessonLikeResponses;

public class CreatedLessonLikeResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid LessonId { get; set; }
}
