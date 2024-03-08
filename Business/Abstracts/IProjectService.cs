using Business.Dtos.Requests.ProjectRequests;
using Business.Dtos.Responses.ProjectResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProjectService
    {
        Task<IPaginate<GetListProjectResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListProjectResponse> GetByIdAsync(Guid id);
        Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest);
        Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest);
        Task<DeletedProjectResponse> DeleteAsync(DeleteProjectRequest deleteProjectRequest);
    }
}
