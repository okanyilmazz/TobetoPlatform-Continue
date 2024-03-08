namespace Business.Dtos.Responses.ExamQuestionTypeResponses;

public class CreatedExamQuestionTypeResponse
{
    public Guid Id { get; set; }
    public Guid QuestionTypeId { get; set; }
    public Guid ExamId { get; set; }
}
