using Business.Dtos.Requests.EducationProgramProgrammingLanguageRequests;
using Business.Dtos.Responses.EducationProgramProgrammingLanguageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramProgrammingLanguageService
{
    Task<CreatedEducationProgramProgrammingLanguageResponse> AddAsync(CreateEducationProgramProgrammingLanguageRequest createEducationProgramProgrammingLanguageRequest);
    Task<DeletedEducationProgramProgrammingLanguageResponse> DeleteAsync(Guid id);
    Task<UpdatedEducationProgramProgrammingLanguageResponse> UpdateAsync(UpdateEducationProgramProgrammingLanguageRequest updateEducationProgramProgrammingLanguageRequest);
    Task<IPaginate<GetListEducationProgramProgrammingLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetEducationProgramProgrammingLanguageResponse> GetByIdAsync(Guid id);
}
