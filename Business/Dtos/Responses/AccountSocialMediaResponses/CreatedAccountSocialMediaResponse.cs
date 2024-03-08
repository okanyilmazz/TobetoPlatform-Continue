namespace Business.Dtos.Responses.AccountSocialMediaResponses;

public class CreatedAccountSocialMediaResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Url { get; set; }
}
