namespace Business.Dtos.Responses.AccountBadgeResponses;

public class CreatedAccountBadgeResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid BadgeId { get; set; }
}