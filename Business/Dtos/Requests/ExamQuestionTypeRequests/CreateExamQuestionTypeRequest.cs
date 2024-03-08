namespace Business.Dtos.Requests.ExamQuestionTypeRequests
{
    public class CreateExamQuestionTypeRequest
    {
        public Guid QuestionTypeId { get; set; }
        public Guid ExamId { get; set; }
    }
}