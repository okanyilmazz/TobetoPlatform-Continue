namespace Business.Dtos.Requests.CompetenceTestRequests;

public class UpdateCompetenceTestRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuestionCount { get; set; }
}
