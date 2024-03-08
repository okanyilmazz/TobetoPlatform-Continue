namespace Business.Dtos.Responses.BadgeResponses;

public class GetBadgeResponse
{
    public Guid Id { get; set; }
    public string ThumbnailPath { get; set; }
    public string Name { get; set; }
}