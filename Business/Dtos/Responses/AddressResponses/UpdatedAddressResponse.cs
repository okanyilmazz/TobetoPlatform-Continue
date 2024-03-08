namespace Business.Dtos.Responses.AddressResponses;

public class UpdatedAddressResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid CityId { get; set; }
    public Guid CountryId { get; set; }
    public Guid DistrictId { get; set; }
    public string AddressDetail { get; set; }
}
