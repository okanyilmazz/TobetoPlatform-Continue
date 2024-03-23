using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Responses.AccountResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountService
{
    Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest);
    Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest);
    Task<DeletedAccountResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountResponse>> GetStudentBySessionIdAsync(Guid sessionId);
    Task<IPaginate<GetListAccountResponse>> GetInstructorBySessionIdAsync(Guid sessionId);
    Task<GetAccountResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListAccountResponse>> GetByLessonIdForLikeAsync(Guid lessonId, PageRequest pageRequest);
    Task<IPaginate<GetListAccountResponse>> GetByEducationProgramIdForLikeAsync(Guid educationProgramId, PageRequest pageRequest);   
}
