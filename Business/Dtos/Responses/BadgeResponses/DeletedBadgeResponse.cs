namespace Business.Dtos.Responses.BadgeResponses;

public class DeletedBadgeResponse
{
    public Guid Id { get; set; }
    public string ThumbnailPath { get; set; }
    public string Name { get; set; }
}