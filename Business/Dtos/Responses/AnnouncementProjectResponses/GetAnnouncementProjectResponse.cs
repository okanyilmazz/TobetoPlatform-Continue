using Business.Dtos.Responses.AnnouncementResponses;
using Business.Dtos.Responses.ProjectResponses;

namespace Business.Dtos.Responses.AnnouncementProjectResponses;

public class GetAnnouncementProjectResponse
{
    public Guid Id { get; set; }

    public virtual GetListAnnouncementResponse Announcement { get; set; }
    public virtual GetListProjectResponse Project { get; set; }
}