namespace Business.Dtos.Requests.BadgeRequests;

public class UpdateBadgeRequest
{
    public Guid Id { get; set; }
    public string ThumbnailPath { get; set; }
    public string Name { get; set; }
}