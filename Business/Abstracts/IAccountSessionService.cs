using Business.Dtos.Requests.AccountSessionRequests;
using Business.Dtos.Responses.AccountSessionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountSessionService
{
    Task<CreatedAccountSessionResponse> AddAsync(CreateAccountSessionRequest createAccountSessionRequest);
    Task<UpdatedAccountSessionResponse> UpdateAsync(UpdateAccountSessionRequest updateAccountSessionRequest);
    Task<DeletedAccountSessionResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountSessionResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountSessionResponse>> GetByAccountIdAsync(Guid accountId);    
    Task<GetAccountSessionResponse> GetByIdAsync(Guid id);
    Task<GetAccountSessionResponse> GetByAccountAndSessionIdAsync(Guid accountId, Guid sessionId);
}