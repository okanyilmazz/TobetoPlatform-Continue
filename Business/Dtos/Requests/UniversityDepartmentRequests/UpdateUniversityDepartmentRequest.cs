namespace Business.Dtos.Requests.UniversityDepartmentRequests
{
    public class UpdateUniversityDepartmentRequest
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}