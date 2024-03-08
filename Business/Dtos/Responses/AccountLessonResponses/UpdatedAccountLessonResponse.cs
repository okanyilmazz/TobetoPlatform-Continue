namespace Business.Dtos.Responses.AccountLessonResponses;

public class UpdatedAccountLessonResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid AccountId { get; set; }
}