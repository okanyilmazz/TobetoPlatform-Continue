using Business.Dtos.Requests.AnnouncementRequests;
using Business.Dtos.Responses.AnnouncementResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAnnouncementService
{
    Task<CreatedAnnouncementResponse> AddAsync(CreateAnnouncementRequest createAnnouncementRequest);
    Task<UpdatedAnnouncementResponse> UpdateAsync(UpdateAnnouncementRequest updateAnnouncementRequest);

    Task<DeletedAnnouncementResponse> DeleteAsync(DeleteAnnouncementRequest deleteAnnouncementRequest);

    Task<IPaginate<GetListAnnouncementResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAnnouncementResponse> GetByIdAsync(Guid Id);
}