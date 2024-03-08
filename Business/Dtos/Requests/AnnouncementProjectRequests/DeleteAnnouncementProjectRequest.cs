namespace Business.Dtos.Requests.AnnouncementProjectRequests
{
    public class DeleteAnnouncementProjectRequest
    {
        public Guid Id { get; set; }
        public Guid AnnouncementId { get; set; }
        public Guid ProjectId { get; set; }
    }
}