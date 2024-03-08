namespace Business.Dtos.Responses.ExamQuestionTypeResponses;

public class DeletedExamQuestionTypeResponse
{
    public Guid Id { get; set; }
    public Guid QuestionTypeId { get; set; }
    public Guid ExamId { get; set; }
}