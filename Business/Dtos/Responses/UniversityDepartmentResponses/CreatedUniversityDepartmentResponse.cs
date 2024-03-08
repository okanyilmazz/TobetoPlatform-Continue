namespace Business.Dtos.Responses.UniversityDepartmentResponses;

public class CreatedUniversityDepartmentResponse
{
    public Guid Id { get; set; }
    public Guid UniversityId { get; set; }
    public string Name { get; set; }
}