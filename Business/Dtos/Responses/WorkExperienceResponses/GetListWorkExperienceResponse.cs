namespace Business.Dtos.Responses.WorkExperienceResponses;

public class GetListWorkExperienceResponse
{
    public Guid Id { get; set; }
    public string CityName { get; set; }
    public string AccountName { get; set; }
    public string Industry { get; set; }
    public string CompanyName { get; set; }
    public string Department { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
