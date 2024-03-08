using System;
namespace Business.Dtos.Requests.ExamQuestionRequests
{
    public class CreateExamQuestionRequest
    {
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }
}

