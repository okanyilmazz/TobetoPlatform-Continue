using System;
namespace Business.Dtos.Requests.CountryRequests;

public class UpdateCountryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}


