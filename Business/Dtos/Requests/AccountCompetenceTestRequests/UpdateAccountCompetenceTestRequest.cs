namespace Business.Dtos.Requests.AccountCompetenceTestRequests;

public class UpdateAccountCompetenceTestRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid CompetenceTestId { get; set; }
}
