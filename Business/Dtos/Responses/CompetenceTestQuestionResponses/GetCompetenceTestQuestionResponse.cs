namespace Business.Dtos.Responses.CompetenceTestQuestionResponses;

public class GetCompetenceTestQuestionResponse
{
    public Guid Id { get; set; }
    public Guid CompetenceTestId { get; set; }
    public Guid CompetenceQuestionId { get; set; }
}
