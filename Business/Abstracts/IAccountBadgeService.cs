using Business.Dtos.Requests.AccountBadgeRequests;
using Business.Dtos.Responses.AccountBadgeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountBadgeService
{
    Task<CreatedAccountBadgeResponse> AddAsync(CreateAccountBadgeRequest createAccountBadgeRequest);
    Task<UpdatedAccountBadgeResponse> UpdateAsync(UpdateAccountBadgeRequest updateAccountBadgeRequest);
    Task<DeletedAccountBadgeResponse> DeleteAsync(DeleteAccountBadgeRequest deleteAccountBadgeRequest);
    Task<GetListAccountBadgeResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListAccountBadgeResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountBadgeResponse>> GetByAccountIdAsync(Guid Id);
    Task<GetListAccountBadgeResponse> GetByAccountAndBadgeIdAsync(Guid accountId, Guid badgeId);
}