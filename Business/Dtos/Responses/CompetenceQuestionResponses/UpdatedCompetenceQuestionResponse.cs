namespace Business.Dtos.Responses.CompetenceQuestionResponses;

public class UpdatedCompetenceQuestionResponse
{
    public Guid Id { get; set; }
    public Guid CompetenceCategoryId { get; set; }
    public string Description { get; set; }
    public int MaxOption { get; set; }
}
