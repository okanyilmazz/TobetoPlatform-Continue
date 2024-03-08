namespace Business.Dtos.Requests.AccountCompetenceTestRequests;

public class CreateAccountCompetenceTestRequest
{
    public Guid AccountId { get; set; }
    public Guid CompetenceTestId { get; set; }
}
