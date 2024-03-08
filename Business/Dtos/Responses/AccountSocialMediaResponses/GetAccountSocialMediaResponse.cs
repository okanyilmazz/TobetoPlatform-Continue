namespace Business.Dtos.Responses.AccountSocialMediaResponses;

public class GetAccountSocialMediaResponse
{
    public Guid Id { get; set; }
    public Guid SocialMediaId { get; set; }
    public string AccountName { get; set; }
    public string SocialMediaName { get; set; }
    public string Url { get; set; }
    public string IconPath { get; set; }
}
