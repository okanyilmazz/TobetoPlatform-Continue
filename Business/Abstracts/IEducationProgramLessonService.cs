using Business.Dtos.Requests.EducationProgramLessonRequests;
using Business.Dtos.Responses.EducationProgramLessonResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramLessonService
{
    Task<CreatedEducationProgramLessonResponse> AddAsync(CreateEducationProgramLessonRequest createEducationProgramLessonRequest);
    Task<UpdatedEducationProgramLessonResponse> UpdateAsync(UpdateEducationProgramLessonRequest updateEducationProgramLessonRequest);
    Task<DeletedEducationProgramLessonResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListEducationProgramLessonResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetEducationProgramLessonResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListEducationProgramLessonResponse>> GetByEducationProgramIdAsync(Guid educationProgramId);
}
