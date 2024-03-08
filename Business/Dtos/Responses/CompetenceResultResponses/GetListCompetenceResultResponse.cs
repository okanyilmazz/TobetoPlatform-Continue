namespace Business.Dtos.Responses.CompetenceResultResponses;

public class GetListCompetenceResultResponse
{
    public Guid Id { get; set; }
    public Guid CompetenceCategoryId { get; set; }
    public Guid AccountId { get; set; }
    public double Point { get; set; }
}
