namespace Business.Dtos.Responses.ExamQuestionResponses;

public class GetListExamQuestionResponse
{
    public Guid Id { get; set; }
    public string QuestionName { get; set; }
    public string ExamName { get; set; }
}