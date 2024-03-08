namespace Business.Dtos.Requests.UniversityDepartmentRequests
{
    public class CreateUniversityDepartmentRequest
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}