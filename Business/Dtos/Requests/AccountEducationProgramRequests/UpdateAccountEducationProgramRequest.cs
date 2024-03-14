namespace Business.Dtos.Requests.AccountEducationProgramRequests;

public class UpdateAccountEducationProgramRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
    public double StatusPercent { get; set; }
    public double TimeSpent { get; set; }
}
