using Business.Dtos.Requests.AccountActivityMapRequests;
using Business.Dtos.Responses.AccountActivityMapResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountActivityMapService
{
    Task<CreatedAccountActivityMapResponse> AddAsync(CreateAccountActivityMapRequest createAccountActivityMapRequest);
    Task<UpdatedAccountActivityMapResponse> UpdateAsync(UpdateAccountActivityMapRequest updateAccountActivityMapRequest);
    Task<DeletedAccountActivityMapResponse> DeleteAsync(Guid id);
    Task<GetAccountActivityMapResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListAccountActivityMapResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountActivityMapResponse>> GetByAccountIdAsync(Guid Id);
}

