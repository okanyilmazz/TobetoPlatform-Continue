namespace Business.Dtos.Responses.AccountAnswerResponses;

public class UpdatedAccountAnswerResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public Guid QuestionId { get; set; }
    public string GivenAnswer { get; set; }
}
