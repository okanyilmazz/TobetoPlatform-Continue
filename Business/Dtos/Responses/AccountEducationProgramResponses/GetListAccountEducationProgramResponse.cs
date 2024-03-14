namespace Business.Dtos.Responses.AccountEducationProgramResponses;

public class GetListAccountEducationProgramResponse
{
    public Guid Id { get; set; }
    public string AccountName { get; set; }
    public string EducationProgramName { get; set; }
    public double StatusPercent { get; set; }
    public double TimeSpent { get; set; }
}