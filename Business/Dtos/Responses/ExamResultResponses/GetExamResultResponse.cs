namespace Business.Dtos.Responses.ExamResultResponses;

public class GetExamResultResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public string ExamName { get; set; }
    public int CorrectOptionCount { get; set; }
    public int InCorrectOptionCount { get; set; }
    public int EmptyOptionCount { get; set; }
    public int Result { get; set; }
    public DateTime CreatedDate { get; set; }
}