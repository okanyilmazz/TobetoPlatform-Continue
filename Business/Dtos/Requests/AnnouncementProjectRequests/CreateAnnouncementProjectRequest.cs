namespace Business.Dtos.Requests.AnnouncementProjectRequests
{
    public class CreateAnnouncementProjectRequest
    {
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}