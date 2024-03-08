using Business.Dtos.Requests.BadgeRequests;
using Business.Dtos.Responses.BadgeResponses;
using Business.Dtos.Responses.SkillResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IBadgeService
{
    Task<CreatedBadgeResponse> AddAsync(CreateBadgeRequest createBadgeRequest);
    Task<UpdatedBadgeResponse> UpdateAsync(UpdateBadgeRequest updateBadgeRequest);
    Task<DeletedBadgeResponse> DeleteAsync(DeleteBadgeRequest deleteBadgeRequest);
    Task<IPaginate<GetListBadgeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListBadgeResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListBadgeResponse>> GetByAccountIdAsync(Guid id);

}
