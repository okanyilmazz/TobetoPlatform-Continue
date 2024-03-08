namespace Business.Dtos.Responses.AccountResponses;

public class UpdatedAccountResponse
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalId { get; set; }
    public string Description { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ProfilePhotoPath { get; set; }
}