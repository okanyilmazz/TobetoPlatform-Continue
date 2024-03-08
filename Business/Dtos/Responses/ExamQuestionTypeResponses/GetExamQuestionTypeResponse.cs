namespace Business.Dtos.Responses.ExamQuestionTypeResponses;

public class GetExamQuestionTypeResponse
{
    public Guid Id { get; set; }
    public string ExamName { get; set; }
    public string QuestionTypeName { get; set; }
}