namespace Business.Dtos.Requests.AnnouncementReadRequests;

public class CreateAnnouncementReadRequest
{
    public Guid AccountId { get; set; }
    public Guid AnnouncementId { get; set; }
}
