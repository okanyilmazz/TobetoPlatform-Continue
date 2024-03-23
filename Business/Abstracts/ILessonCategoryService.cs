using Business.Dtos.Requests.LessonCategoryRequests;
using Business.Dtos.Responses.LessonCategoryResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILessonCategoryService
{
    Task<CreatedLessonCategoryResponse> AddAsync(CreateLessonCategoryRequest createLessonCategoryRequest);
    Task<UpdatedLessonCategoryResponse> UpdateAsync(UpdateLessonCategoryRequest updateLessonCategoryRequest);
    Task<DeletedLessonCategoryResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListLessonCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetLessonCategoryResponse> GetByIdAsync(Guid id);
}
