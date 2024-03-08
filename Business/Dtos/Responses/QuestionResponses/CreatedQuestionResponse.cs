namespace Business.Dtos.Responses.QuestionResponses;

public class CreatedQuestionResponse
{
    public Guid Id { get; set; }
    public Guid QuestionTypeId { get; set; }
    public string Description { get; set; }
    public string OptionA { get; set; }
    public string OptionB { get; set; }
    public string OptionC { get; set; }
    public string OptionD { get; set; }
    public string CorrectOption { get; set; }
}
