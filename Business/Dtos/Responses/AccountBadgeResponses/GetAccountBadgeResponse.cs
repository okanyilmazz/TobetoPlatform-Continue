namespace Business.Dtos.Responses.AccountBadgeResponses;

public class GetAccountBadgeResponse
{
    public Guid Id { get; set; }
    public string AccountName { get; set; }
    public string BadgeThumbnail { get; set; }
}