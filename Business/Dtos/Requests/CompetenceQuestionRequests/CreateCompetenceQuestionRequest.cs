namespace Business.Dtos.Requests.CompetenceQuestionRequests;

public class CreateCompetenceQuestionRequest
{
    public Guid CompetenceCategoryId { get; set; }
    public string Description { get; set; }
    public int MaxOption { get; set; }
}
