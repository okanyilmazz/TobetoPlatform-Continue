using Business.Dtos.Requests.LessonModuleRequests;
using Business.Dtos.Responses.LessonModuleResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILessonModuleService
{
    Task<CreatedLessonModuleResponse> AddAsync(CreateLessonModuleRequest createLessonModuleRequest);
    Task<UpdatedLessonModuleResponse> UpdateAsync(UpdateLessonModuleRequest updateLessonModuleRequest);
    Task<DeletedLessonModuleResponse> DeleteAsync(DeleteLessonModuleRequest deleteLessonModuleRequest);
    Task<IPaginate<GetListLessonModuleResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetLessonModuleResponse> GetByIdAsync(Guid id);
}
