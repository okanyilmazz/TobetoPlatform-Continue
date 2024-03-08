namespace Business.Dtos.Responses.QuestionResponses;

public class GetQuestionResponse
{
    public Guid Id { get; set; }
    public string QuestionTypeName { get; set; }
    public string Description { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string CorrectOption { get; set; }
}
