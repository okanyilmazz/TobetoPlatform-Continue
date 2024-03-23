using Business.Dtos.Requests.WorkExperienceResquests;
using Business.Dtos.Responses.WorkExperienceResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IWorkExperienceService
{
    Task<CreatedWorkExperienceResponse> AddAsync(CreateWorkExperienceRequest createWorkExperienceRequest);
    Task<DeletedWorkExperienceResponse> DeleteAsync(Guid id);
    Task<UpdatedWorkExperienceResponse> UpdateAsync(UpdateWorkExperienceRequest updateWorkExperienceRequest);
    Task<IPaginate<GetListWorkExperienceResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetWorkExperienceResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListWorkExperienceResponse>> GetByAccountIdAsync(Guid accountId);
}
