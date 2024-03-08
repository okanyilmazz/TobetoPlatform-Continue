namespace Business.Dtos.Responses.ExamQuestionResponses;

public class DeletedExamQuestionResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}