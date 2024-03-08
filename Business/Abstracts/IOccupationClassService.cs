using Business.Dtos.Requests.OccupationClassRequests;
using Business.Dtos.Responses.OccupationClassResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IOccupationClassService
{
    Task<CreatedOccupationClassResponse> AddAsync(CreateOccupationClassRequest createOccupationClassRequest);
    Task<UpdatedOccupationClassResponse> UpdateAsync(UpdateOccupationClassRequest updateOccupationClassRequest);
    Task<DeletedOccupationClassResponse> DeleteAsync(DeleteOccupationClassRequest deleteOccupationClassRequest);
    Task<IPaginate<GetListOccupationClassResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetOccupationClassResponse> GetByIdAsync(Guid id);
    Task<GetOccupationClassResponse> GetByAccountIdAsync(Guid accountId);
}