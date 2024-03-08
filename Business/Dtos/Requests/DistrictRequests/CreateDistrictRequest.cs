namespace Business.Dtos.Requests.DistrictRequests
{
    public class CreateDistrictRequest
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}