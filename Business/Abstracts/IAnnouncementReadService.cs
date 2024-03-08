using Business.Dtos.Requests.AnnouncementReadRequests;
using Business.Dtos.Responses.AnnouncementReadResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAnnouncementReadService
{
    Task<CreatedAnnouncementReadResponse> AddAsync(CreateAnnouncementReadRequest createAnnouncementReadRequest);
    Task<UpdatedAnnouncementReadResponse> UpdateAsync(UpdateAnnouncementReadRequest updateAnnouncementReadRequest);

    Task<DeletedAnnouncementReadResponse> DeleteAsync(DeleteAnnouncementReadRequest deleteAnnouncementReadRequest);

    Task<IPaginate<GetListAnnouncementReadResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAnnouncementReadResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListAnnouncementReadResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListAnnouncementReadResponse>> GetByAnnouncementIdAsync(Guid announcementId);
}