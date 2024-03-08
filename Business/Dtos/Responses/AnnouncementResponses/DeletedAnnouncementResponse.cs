namespace Business.Dtos.Responses.AnnouncementResponses;

public class DeletedAnnouncementResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime AnnouncementDate { get; set; }
    public Guid AnnouncementTypeId { get; set; }

}