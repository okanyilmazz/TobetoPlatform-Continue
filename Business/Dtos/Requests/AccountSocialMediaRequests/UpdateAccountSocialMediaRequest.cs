namespace Business.Dtos.Requests.AccountSocialMediaRequests
{
    public class UpdateAccountSocialMediaRequest
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid SocialMediaId { get; set; }
        public string Url { get; set; }
    }
}
