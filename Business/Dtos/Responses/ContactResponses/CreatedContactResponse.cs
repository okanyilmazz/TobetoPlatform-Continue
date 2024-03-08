namespace Business.Dtos.Responses.ContactResponses;

public class CreatedContactResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
