namespace Business.Dtos.Responses.AccountLessonResponses;

public class CreatedAccountLessonResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid AccountId { get; set; }
}