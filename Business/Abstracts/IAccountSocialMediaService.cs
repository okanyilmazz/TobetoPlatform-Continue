using Business.Dtos.Requests.AccountSocialMediaRequests;
using Business.Dtos.Responses.AccountSocialMediaResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountSocialMediaService
{
    Task<CreatedAccountSocialMediaResponse> AddAsync(CreateAccountSocialMediaRequest createAccountSocialMediaRequest);
    Task<UpdatedAccountSocialMediaResponse> UpdateAsync(UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest);
    Task<DeletedAccountSocialMediaResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountSocialMediaResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAccountSocialMediaResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListAccountSocialMediaResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest);
}