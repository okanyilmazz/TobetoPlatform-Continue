using Business.Dtos.Requests.ActivityMapRequests;
using Business.Dtos.Responses.ActivityMapResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IActivityMapService
	{
        Task<CreatedActivityMapResponse> AddAsync(CreateActivityMapRequest createActivityMapRequest);
        Task<UpdatedActivityMapResponse> UpdateAsync(UpdateActivityMapRequest updateActivityMapRequest);
        Task<DeletedActivityMapResponse> DeleteAsync(DeleteActivityMapRequest deleteActivityMapRequest);
        Task<IPaginate<GetListActivityMapResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetActivityMapResponse> GetByIdAsync(Guid Id);
        Task<IPaginate<GetListActivityMapResponse>> GetByAccountIdAsync(Guid id);
    }
}

