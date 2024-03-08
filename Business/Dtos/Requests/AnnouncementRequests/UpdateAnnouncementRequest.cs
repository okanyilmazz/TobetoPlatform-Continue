namespace Business.Dtos.Requests.AnnouncementRequests;

public class UpdateAnnouncementRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime AnnouncementDate { get; set; }
    public Guid AnnouncementTypeId { get; set; }
}