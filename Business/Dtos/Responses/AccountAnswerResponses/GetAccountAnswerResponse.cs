namespace Business.Dtos.Responses.AccountAnswerResponses;

public class GetAccountAnswerResponse
{
    public Guid Id { get; set; }
    public string AccountName { get; set; }
    public string ExamName { get; set; }
    public string QuestionName { get; set; }
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public Guid QuestionId { get; set; }
    public string GivenAnswer { get; set; }
}
