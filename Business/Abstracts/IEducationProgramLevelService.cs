using Business.Dtos.Requests.EducationProgramLevelRequests;
using Business.Dtos.Responses.EducationProgramLevelResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramLevelService
{
    Task<CreatedEducationProgramLevelResponse> AddAsync(CreateEducationProgramLevelRequest createEducationProgramLevelRequest);
    Task<DeletedEducationProgramLevelResponse> DeleteAsync(DeleteEducationProgramLevelRequest deleteEducationProgramLevelRequest);
    Task<UpdatedEducationProgramLevelResponse> UpdateAsync(UpdateEducationProgramLevelRequest updateEducationProgramLevelRequest);
    Task<IPaginate<GetListEducationProgramLevelResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetEducationProgramLevelResponse> GetByIdAsync(Guid id);
}