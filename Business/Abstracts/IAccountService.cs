using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Responses.AccountResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountService
{
    Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest);
    Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest);
    Task<DeletedAccountResponse> DeleteAsync(DeleteAccountRequest deleteAccountRequest);
    Task<IPaginate<GetListAccountResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountResponse>> GetBySessionIdAsync(Guid id);
    Task<GetListAccountResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListAccountResponse>> GetByLessonIdForLikeAsync(Guid lessonId, PageRequest pageRequest);
    Task<IPaginate<GetListAccountResponse>> GetByEducationProgramIdForLikeAsync(Guid educationProgramId, PageRequest pageRequest);   
}
