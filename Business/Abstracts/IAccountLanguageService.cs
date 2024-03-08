using Business.Dtos.Requests.AccountLanguageRequests;
using Business.Dtos.Responses.AccountLanguageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountLanguageService
{
    Task<CreatedAccountLanguageResponse> AddAsync(CreateAccountLanguageRequest createAccountLanguageRequest);
    Task<UpdatedAccountLanguageResponse> UpdateAsync(UpdateAccountLanguageRequest updateAccountLanguageRequest);
    Task<DeletedAccountLanguageResponse> DeleteAsync(DeleteAccountLanguageRequest deleteAccountLanguageRequest);
    Task<IPaginate<GetListAccountLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAccountLanguageResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListAccountLanguageResponse>> GetByAccountIdAsync(Guid accountId);
}
