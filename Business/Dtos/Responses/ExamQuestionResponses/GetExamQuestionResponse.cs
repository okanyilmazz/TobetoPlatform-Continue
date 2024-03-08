namespace Business.Dtos.Responses.ExamQuestionResponses;

public class GetExamQuestionResponse
{
    public Guid Id { get; set; }
    public string QuestionName { get; set; }
    public string ExamName { get; set; }
}