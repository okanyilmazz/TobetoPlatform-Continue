namespace Business.Dtos.Requests.CityRequests
{
    public class CreateCityRequest
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}