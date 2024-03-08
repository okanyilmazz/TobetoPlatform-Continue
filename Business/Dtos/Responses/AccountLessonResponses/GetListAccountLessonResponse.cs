namespace Business.Dtos.Responses.AccountLessonResponses;

public class GetListAccountLessonResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public Guid AccountId { get; set; }

    public string LessonName { get; set; }
    public string AccountName { get; set; }
    public double StatusPercent { get; set; }
    public string LessonPath { get; set; }

}