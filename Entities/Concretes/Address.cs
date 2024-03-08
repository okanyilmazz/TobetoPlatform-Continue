using Core.Entities;

namespace Entities.Concretes;

public class Address : Entity<Guid>
{
    public Guid? AccountId { get; set; }
    public Guid? CityId { get; set; }
    public Guid? CountryId { get; set; }
    public Guid? DistrictId { get; set; }
    public string AddressDetail { get; set; }

    public City? City { get; set; }
    public Country? Country { get; set; }
    public District? District { get; set; }
    public Account? Account { get; set; }
}
