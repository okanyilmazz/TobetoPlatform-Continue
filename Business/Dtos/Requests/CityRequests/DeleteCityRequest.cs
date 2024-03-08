namespace Business.Dtos.Requests.CityRequests
{
    public class DeleteCityRequest
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}