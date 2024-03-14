namespace Business.Dtos.Responses.AccountEducationProgramResponses;

public class UpdatedAccountEducationProgramResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
    public double StatusPercent { get; set; }
    public int TimeSpent { get; set; }
}