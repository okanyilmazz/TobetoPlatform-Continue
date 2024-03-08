using Business.Dtos.Requests.LessonRequests;
using Business.Dtos.Responses.LessonResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILessonService
    {
        Task<CreatedLessonResponse> AddAsync(CreateLessonRequest createLessonRequest);
        Task<DeletedLessonResponse> DeleteAsync(DeleteLessonRequest deleteLessonRequest);
        Task<UpdatedLessonResponse> UpdateAsync(UpdateLessonRequest updateLessonRequest);
        Task<IPaginate<GetListLessonResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListLessonResponse> GetByIdAsync(Guid id);
        Task<IPaginate<GetListLessonResponse>> GetByAccountIdAsync(Guid id);
        Task<IPaginate<GetListLessonResponse>> GetByEducationProgramIdAsync(Guid id);
    }
}
