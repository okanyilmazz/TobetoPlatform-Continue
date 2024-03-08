namespace Business.Dtos.Requests.DistrictRequests
{
    public class DeleteDistrictRequest
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}