namespace Business.Dtos.Requests.AccountBadgeRequests;

public class UpdateAccountBadgeRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid BadgeId { get; set; }
}