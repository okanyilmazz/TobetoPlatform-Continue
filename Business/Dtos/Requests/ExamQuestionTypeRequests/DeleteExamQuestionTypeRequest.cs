namespace Business.Dtos.Requests.ExamQuestionTypeRequests
{
    public class DeleteExamQuestionTypeRequest
    {
        public Guid Id { get; set; }
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }
    }
}