namespace Business.Dtos.Requests.AnnouncementReadRequests;

public class DeleteAnnouncementReadRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid AnnouncementId { get; set; }

}
