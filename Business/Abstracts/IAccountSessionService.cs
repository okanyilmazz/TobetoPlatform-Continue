using Business.Dtos.Requests.AccountSessionRequests;
using Business.Dtos.Responses.AccountSessionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountSessionService
{
    Task<CreatedAccountSessionResponse> AddAsync(CreateAccountSessionRequest createAccountSessionRequest);
    Task<UpdatedAccountSessionResponse> UpdateAsync(UpdateAccountSessionRequest updateAccountSessionRequest);
    Task<DeletedAccountSessionResponse> DeleteAsync(DeleteAccountSessionRequest deleteAccountSessionRequest);
    Task<IPaginate<GetListAccountSessionResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountSessionResponse>> GetByAccountIdAsync(Guid accountId);    
    Task<GetListAccountSessionResponse> GetByIdAsync(Guid id);
    Task<GetListAccountSessionResponse> GetByAccountAndSessionIdAsync(Guid accountId, Guid sessionId);
}