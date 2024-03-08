namespace Business.Dtos.Responses.AccountUniversityResponses;

public class UpdatedAccountUniversityResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid DegreeTypeId { get; set; }
    public Guid UniversityId { get; set; }
    public Guid UniversityDepartmentId { get; set; }
    public string StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool IsEducationActive { get; set; }
}