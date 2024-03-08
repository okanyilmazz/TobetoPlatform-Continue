namespace Business.Dtos.Responses.CityResponses
{
    public class DeletedCityResponse
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}