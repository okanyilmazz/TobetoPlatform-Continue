namespace Business.Dtos.Requests.AccountEducationProgramRequests;

public class DeleteAccountEducationProgramRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
    public double StatusPercent { get; set; }
    public int TimeSpent { get; set; }
}
