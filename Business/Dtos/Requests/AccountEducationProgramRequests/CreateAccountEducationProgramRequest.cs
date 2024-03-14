namespace Business.Dtos.Requests.AccountEducationProgramRequests;

public class CreateAccountEducationProgramRequest
{
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
    public double StatusPercent { get; set; }
    public double TimeSpent { get; set; }
}
