using Business.Dtos.Requests;
using Business.Dtos.Requests.LessonModuleRequests;
using Business.Dtos.Responses;
using Business.Dtos.Responses.LessonModuleResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILessonModuleService
    {
        Task<CreatedLessonModuleResponse> AddAsync(CreateLessonModuleRequest createLessonModuleRequest);
        Task<UpdatedLessonModuleResponse> UpdateAsync(UpdateLessonModuleRequest updateLessonModuleRequest);
        Task<DeletedLessonModuleResponse> DeleteAsync(DeleteLessonModuleRequest deleteLessonModuleRequest);
        Task<IPaginate<GetListLessonModuleResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListLessonModuleResponse> GetByIdAsync(Guid id);
    }
}

