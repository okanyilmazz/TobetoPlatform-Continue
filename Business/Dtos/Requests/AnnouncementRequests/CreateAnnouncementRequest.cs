namespace Business.Dtos.Requests.AnnouncementRequests;

public class CreateAnnouncementRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime AnnouncementDate { get; set; }
    public Guid AnnouncementTypeId { get; set; }
}