using Business.Dtos.Requests.LessonCategoryRequests;
using Business.Dtos.Responses.LessonCategoryResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILessonCategoryService
    {
        Task<CreatedLessonCategoryResponse> AddAsync(CreateLessonCategoryRequest createLessonCategoryRequest);
        Task<UpdatedLessonCategoryResponse> UpdateAsync(UpdateLessonCategoryRequest updateLessonCategoryRequest);
        Task<DeletedLessonCategoryResponse> DeleteAsync(DeleteLessonCategoryRequest deleteLessonCategoryRequest);
        Task<IPaginate<GetListLessonCategoryResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListLessonCategoryResponse> GetByIdAsync(Guid id);
    }
}
