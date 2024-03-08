namespace Business.Dtos.Responses.ExamResponses;

public class GetExamResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int QuestionCount { get; set; }
    public List<string> QuestionTypeNames { get; set; }
}