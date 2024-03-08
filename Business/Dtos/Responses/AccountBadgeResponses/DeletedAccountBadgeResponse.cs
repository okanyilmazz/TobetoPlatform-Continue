namespace Business.Dtos.Responses.AccountBadgeResponses;

public class DeletedAccountBadgeResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid BadgeId { get; set; }
}