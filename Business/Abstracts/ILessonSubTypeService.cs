using Business.Dtos.Requests.LessonSubTypeRequests;
using Business.Dtos.Responses.LessonSubTypeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILessonSubTypeService
{
    Task<CreatedLessonSubTypeResponse> AddAsync(CreateLessonSubTypeRequest createLessonSubTypeRequest);
    Task<UpdatedLessonSubTypeResponse> UpdateAsync(UpdateLessonSubTypeRequest updateLessonSubTypeRequest);
    Task<DeletedLessonSubTypeResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListLessonSubTypeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetLessonSubTypeResponse> GetByIdAsync(Guid id);
}
