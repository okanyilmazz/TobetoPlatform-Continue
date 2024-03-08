namespace Business.Dtos.Responses.AnnouncementProjectResponses;

public class CreatedAnnouncementProjectResponse
{
    public Guid Id { get; set; }
    public Guid AnnouncementId { get; set; }
    public Guid ProjectId { get; set; }
}