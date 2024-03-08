namespace Business.Dtos.Requests.AnnouncementReadRequests;

public class UpdateAnnouncementReadRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid AnnouncementId { get; set; }
}
