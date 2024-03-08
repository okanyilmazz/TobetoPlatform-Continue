namespace Business.Dtos.Requests.CompetenceTestRequests;

public class CreateCompetenceTestRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuestionCount { get; set; }
}
