namespace Business.Dtos.Responses.WorkExperienceResponses;

public class CreatedWorkExperienceResponse
{
    public Guid Id { get; set; }
    public Guid CityId { get; set; }
    public Guid AccountId { get; set; }
    public string Industry { get; set; }
    public string CompanyName { get; set; }
    public string Department { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
