namespace Business.Dtos.Requests.CompetenceResultRequests;

public class CreateCompetenceResultRequest
{
    public Guid CompetenceCategoryId { get; set; } 
    public Guid AccountId { get; set; }
    public double Point { get; set; }
}