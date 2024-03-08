using Business.Dtos.Requests.AccountAnswerRequests;
using Business.Dtos.Responses.AccountAnswerResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountAnswerService
{
    Task<CreatedAccountAnswerResponse> AddAsync(CreateAccountAnswerRequest createAccountAnswerRequest);
    Task<UpdatedAccountAnswerResponse> UpdateAsync(UpdateAccountAnswerRequest updateAccountAnswerRequest);
    Task<DeletedAccountAnswerResponse> DeleteAsync(DeleteAccountAnswerRequest deleteAccountAnswerRequest);
    Task<IPaginate<GetListAccountAnswerResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountAnswerResponse> GetByIdAsync(Guid id);
}