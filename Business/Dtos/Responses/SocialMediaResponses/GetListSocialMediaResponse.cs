using Entities.Concretes;

namespace Business.Dtos.Responses.SocialMediaResponses;

public class GetListSocialMediaResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }

    public virtual ICollection<Account>? Accounts { get; set; }
}