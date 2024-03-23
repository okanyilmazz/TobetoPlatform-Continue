using Business.Dtos.Requests.HomeworkRequests;
using Business.Dtos.Responses.HomeworkResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IHomeworkService
{
    Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest);
    Task<DeletedHomeworkResponse> DeleteAsync(Guid id);
    Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest);
    Task<IPaginate<GetListHomeworkResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListHomeworkResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListHomeworkResponse>> GetByLessonIdAsync(Guid lessonId);    
    Task<GetHomeworkResponse> GetByIdAsync(Guid id);
}
