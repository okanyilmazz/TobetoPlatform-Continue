using System;
namespace Business.Dtos.Responses.ExamQuestionResponses;

public class CreatedExamQuestionResponse
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public Guid ExamId { get; set; }
}

