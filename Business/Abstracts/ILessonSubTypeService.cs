using Business.Dtos.Requests.LessonSubTypeRequests;
using Business.Dtos.Responses.LessonSubTypeResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILessonSubTypeService
    {
        Task<CreatedLessonSubTypeResponse> AddAsync(CreateLessonSubTypeRequest createLessonSubTypeRequest);
        Task<UpdatedLessonSubTypeResponse> UpdateAsync(UpdateLessonSubTypeRequest updateLessonSubTypeRequest);
        Task<DeletedLessonSubTypeResponse> DeleteAsync(DeleteLessonSubTypeRequest deleteLessonSubTypeRequest);
        Task<IPaginate<GetListLessonSubTypeResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListLessonSubTypeResponse> GetByIdAsync(Guid id);
    }
}
