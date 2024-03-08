using Business.Dtos.Requests.SessionRequests;
using Business.Dtos.Responses.SessionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISessionService
{
    Task<IPaginate<GetListSessionResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListSessionResponse>> GetListWithInstructorAsync(PageRequest pageRequest);
    Task<IPaginate<GetListSessionResponse>> GetByIdWithInstructorAsync(Guid id, PageRequest pageRequest);
    Task<GetSessionResponse> GetByIdAsync(Guid id);
    Task<CreatedSessionResponse> AddAsync(CreateSessionRequest createSessionRequest);
    Task<UpdatedSessionResponse> UpdateAsync(UpdateSessionRequest updateSessionRequest);
    Task<DeletedSessionResponse> DeleteAsync(DeleteSessionRequest deleteSessionRequest);
    Task<IPaginate<GetListSessionResponse>> GetByLessonIdAsync(Guid lessonId);
}
