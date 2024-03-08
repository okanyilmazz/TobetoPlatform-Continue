namespace Business.Dtos.Requests.AccountBadgeRequests;

public class CreateAccountBadgeRequest
{
    public Guid AccountId { get; set; }
    public Guid BadgeId { get; set; }
}