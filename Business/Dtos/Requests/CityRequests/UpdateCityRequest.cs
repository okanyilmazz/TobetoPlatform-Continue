namespace Business.Dtos.Requests.CityRequests
{
    public class UpdateCityRequest
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}