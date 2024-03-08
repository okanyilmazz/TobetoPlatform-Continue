using System;
namespace Business.Dtos.Requests.ExamQuestionRequests;

public class UpdateExamQuestionRequest
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}

