namespace Business.Dtos.Responses.AccountResponses;

public class GetListAccountResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalId { get; set; }
    public string Description { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public string Email { get; set; }
    public string OccupationClassName { get; set; }
    public string OccupationClassId { get; set; }

}