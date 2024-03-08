using Business.Dtos.Requests.AnnouncementProjectRequests;
using Business.Dtos.Responses.AnnouncementProjectResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IAnnouncementProjectService
    {
        Task<CreatedAnnouncementProjectResponse> AddAsync(CreateAnnouncementProjectRequest createAnnouncementProjectRequest);
        Task<UpdatedAnnouncementProjectResponse> UpdateAsync(UpdateAnnouncementProjectRequest updateAnnouncementProjectRequest);

        Task<DeletedAnnouncementProjectResponse> DeleteAsync(DeleteAnnouncementProjectRequest deleteAnnouncementProjectRequest);

        Task<IPaginate<GetListAnnouncementProjectResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetAnnouncementProjectResponse> GetByIdAsync(Guid Id);
    }
}
