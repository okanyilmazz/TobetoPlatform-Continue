namespace Business.Dtos.Responses.CompetenceTestResponses;

public class UpdatedCompetenceTestResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int QuestionCount { get; set; }
}
