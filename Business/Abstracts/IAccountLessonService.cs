using Business.Dtos.Requests.AccountLessonRequests;
using Business.Dtos.Responses.AccountLessonResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountLessonService
{
    Task<CreatedAccountLessonResponse> AddAsync(CreateAccountLessonRequest createLessonOfAccountRequest);
    Task<UpdatedAccountLessonResponse> UpdateAsync(UpdateAccountLessonRequest updateLessonOfAccountRequest);
    Task<DeletedAccountLessonResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountLessonResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAccountLessonResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListAccountLessonResponse>> GetByAccountIdAsync(Guid accountId);
    Task<GetAccountLessonResponse> GetByAccountIdAndLessonIdAsync(Guid accountId, Guid lessonId);
}