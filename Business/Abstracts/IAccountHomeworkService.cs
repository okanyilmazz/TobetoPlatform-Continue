using Business.Dtos.Requests.AccountHomeworkRequests;
using Business.Dtos.Responses.AccountHomeworkResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountHomeworkService
{
    Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest);
    Task<UpdatedAccountHomeworkResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest);
    Task<DeletedAccountHomeworkResponse> DeleteAsync(DeleteAccountHomeworkRequest deleteAccountHomeworkRequest);
    Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListAccountHomeworkResponse> GetByIdAsync(Guid id);
}
