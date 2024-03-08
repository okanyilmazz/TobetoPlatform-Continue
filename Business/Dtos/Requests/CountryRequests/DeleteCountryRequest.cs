using System;
namespace Business.Dtos.Requests.CountryRequests;

public class DeleteCountryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
