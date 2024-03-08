using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProjectRequests;
using Business.Dtos.Responses.ProjectResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ProjectManager : IProjectService
{
    IProjectDal _projectDal;
    IMapper _mapper;
    ProjectBusinessRules _projectBusinessRules;
    public ProjectManager(IProjectDal projectDal, IMapper mapper, ProjectBusinessRules projectBusinessRules)
    {
        _projectDal = projectDal;
        _mapper = mapper;
        _projectBusinessRules = projectBusinessRules;
    }
    public async Task<CreatedProjectResponse> AddAsync(CreateProjectRequest createProjectRequest)
    {
        Project project = _mapper.Map<Project>(createProjectRequest);
        Project addedProject = await _projectDal.AddAsync(project);
        CreatedProjectResponse responseProject = _mapper.Map<CreatedProjectResponse>(addedProject);
        return responseProject;
    }

    public async Task<UpdatedProjectResponse> UpdateAsync(UpdateProjectRequest updateProjectRequest)
    {
        await _projectBusinessRules.IsExistsProject(updateProjectRequest.Id);
        Project project = _mapper.Map<Project>(updateProjectRequest);
        Project updatedProject = await _projectDal.UpdateAsync(project);
        UpdatedProjectResponse responseProject = _mapper.Map<UpdatedProjectResponse>(updatedProject);
        return responseProject;
    }

    public async Task<DeletedProjectResponse> DeleteAsync(DeleteProjectRequest deleteProjectRequest)
    {
        await _projectBusinessRules.IsExistsProject(deleteProjectRequest.Id);
        Project project = await _projectDal.GetAsync(predicate: l => l.Id == deleteProjectRequest.Id);
        await _projectDal.DeleteAsync(project);
        DeletedProjectResponse responseProject = _mapper.Map<DeletedProjectResponse>(project);
        return responseProject;
    }

    public async Task<IPaginate<GetListProjectResponse>> GetListAsync(PageRequest pageRequest)
    {
        var projectListed = await _projectDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
            );
        var mappedListed = _mapper.Map<Paginate<GetListProjectResponse>>(projectListed);
        return mappedListed;
    }

    public async Task<GetProjectResponse> GetByIdAsync(Guid id)
    {
        Project project = await _projectDal.GetAsync(
            predicate: p => p.Id == id);
        var mappedProduct = _mapper.Map<GetProjectResponse>(project);
        return mappedProduct;
    }
}
