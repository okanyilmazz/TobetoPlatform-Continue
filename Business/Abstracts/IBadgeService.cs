using Business.Dtos.Requests.BadgeRequests;
using Business.Dtos.Responses.BadgeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IBadgeService
{
    Task<CreatedBadgeResponse> AddAsync(CreateBadgeRequest createBadgeRequest);
    Task<UpdatedBadgeResponse> UpdateAsync(UpdateBadgeRequest updateBadgeRequest);
    Task<DeletedBadgeResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListBadgeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetBadgeResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListBadgeResponse>> GetByAccountIdAsync(Guid id);
}
