using Business.Dtos.Requests.LessonRequests;
using Business.Dtos.Responses.LessonResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILessonService
{
    Task<CreatedLessonResponse> AddAsync(CreateLessonRequest createLessonRequest);
    Task<DeletedLessonResponse> DeleteAsync(Guid id);
    Task<UpdatedLessonResponse> UpdateAsync(UpdateLessonRequest updateLessonRequest);
    Task<IPaginate<GetListLessonResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetLessonResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListLessonResponse>> GetByAccountIdAsync(Guid id);
    Task<IPaginate<GetListLessonResponse>> GetByEducationProgramIdAsync(Guid id);
}
