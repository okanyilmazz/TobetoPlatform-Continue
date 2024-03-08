using Business.Dtos.Requests.AnnouncementTypeRequests;
using Business.Dtos.Responses.AnnouncementTypeResponse;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAnnouncementTypeService
{
    Task<CreatedAnnouncementTypeResponse> AddAsync(CreateAnnouncementTypeRequest createAnnouncementTypeRequest);
    Task<UpdatedAnnouncementTypeResponse> UpdateAsync(UpdateAnnouncementTypeRequest updateAnnouncementTypeRequest);

    Task<DeletedAnnouncementTypeResponse> DeleteAsync(DeleteAnnouncementTypeRequest deleteAnnouncementTypeRequest);

    Task<IPaginate<GetListAnnouncementTypeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAnnouncementTypeResponse> GetByIdAsync(Guid Id);
}
