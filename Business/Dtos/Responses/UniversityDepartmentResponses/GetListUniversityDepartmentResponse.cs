namespace Business.Dtos.Responses.UniversityDepartmentResponses
{
    public class GetListUniversityDepartmentResponse
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}