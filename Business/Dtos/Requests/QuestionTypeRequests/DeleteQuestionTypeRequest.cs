using System;
namespace Business.Dtos.Requests.QuestionTypeRequests
{
    public class DeleteQuestionTypeRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}