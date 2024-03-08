using Business.Dtos.Requests.EducationProgramSubjectRequests;
using Business.Dtos.Responses.EducationProgramSubjectResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramSubjectService
{
    Task<CreatedEducationProgramSubjectResponse> AddAsync(CreateEducationProgramSubjectRequest createEducationProgramSubjectRequest);
    Task<UpdatedEducationProgramSubjectResponse> UpdateAsync(UpdateEducationProgramSubjectRequest updateEducationProgramSubjectRequest);
    Task<DeletedEducationProgramSubjectResponse> DeleteAsync(DeleteEducationProgramSubjectRequest deleteEducationProgramSubjectRequest);
    Task<IPaginate<GetListEducationProgramSubjectResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetEducationProgramSubjectResponse> GetByIdAsync(Guid id);
}