namespace Business.Dtos.Requests.DistrictRequests
{
    public class UpdateDistrictRequest
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}