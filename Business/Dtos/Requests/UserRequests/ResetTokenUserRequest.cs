namespace Business.Dtos.Requests.UserRequests;

public class ResetTokenUserRequest
{
    public Guid UserId { get; set; }
    public string ResetToken { get; set; }
}
