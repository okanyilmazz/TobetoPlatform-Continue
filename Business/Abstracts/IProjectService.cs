using Business.Dtos.Requests.ProjectRequests;
using Business.Dtos.Responses.ProjectResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProjectService
{
    Task<IPaginate<GetListProjectResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProjectResponse> GetByIdAsync(Guid id);
    Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest);
    Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest);
    Task<DeletedProjectResponse> DeleteAsync(Guid id);
}
