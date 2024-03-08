namespace Business.Dtos.Requests.ExamResultRequests;

public class CreateExamResultRequest
{
    public Guid AccountId { get; set; }
    public Guid ExamId { get; set; }
    public int CorrectOptionCount { get; set; }
    public int InCorrectOptionCount { get; set; }
    public int EmptyOptionCount { get; set; }
    public int Result { get; set; }
}

