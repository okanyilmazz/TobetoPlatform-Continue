namespace Business.Dtos.Responses.UniversityDepartmentResponses;

public class GetUniversityDepartmentResponse
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string Name { get; set; }
}