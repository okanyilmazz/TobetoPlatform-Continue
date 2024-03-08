namespace Business.Dtos.Requests.CompetenceTestQuestionRequests;

public class CreateCompetenceTestQuestionRequest
{
    public Guid Id { get; set; }
    public Guid CompetenceTestId { get; set; }
    public Guid CompetenceQuestionId { get; set; }
}
