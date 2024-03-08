using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.WorkExperienceResquests;
using Business.Dtos.Responses.WorkExperienceResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class WorkExperienceManager : IWorkExperienceService
{
    IWorkExperienceDal _workExperienceDal;
    IMapper _mapper;
    WorkExperienceBusinessRules _workExperienceBusinessRules;
    public WorkExperienceManager(IWorkExperienceDal workExperienceDal, IMapper mapper, WorkExperienceBusinessRules workExperienceBusinessRules)
    {
        _workExperienceDal = workExperienceDal;
        _mapper = mapper;
        _workExperienceBusinessRules = workExperienceBusinessRules;
    }
    public async Task<CreatedWorkExperienceResponse> AddAsync(CreateWorkExperienceRequest createWorkExperienceRequest)
    {
        WorkExperience workExperience = _mapper.Map<WorkExperience>(createWorkExperienceRequest);
        WorkExperience addedWorkExperience = await _workExperienceDal.AddAsync(workExperience);
        CreatedWorkExperienceResponse createdWorkExperienceResponse = _mapper.Map<CreatedWorkExperienceResponse>(addedWorkExperience);
        return createdWorkExperienceResponse;
    }

    public async Task<DeletedWorkExperienceResponse> DeleteAsync(DeleteWorkExperienceRequest deleteWorkExperienceRequest)
    {
        await _workExperienceBusinessRules.IsExistsWorkExperience(deleteWorkExperienceRequest.Id);
        WorkExperience workExperience = await _workExperienceDal.GetAsync(predicate: we => we.Id == deleteWorkExperienceRequest.Id);
        WorkExperience deletedWorkExperience = await _workExperienceDal.DeleteAsync(workExperience);
        DeletedWorkExperienceResponse deletedWorkExperienceResponse = _mapper.Map<DeletedWorkExperienceResponse>(deletedWorkExperience);
        return deletedWorkExperienceResponse;       
    }

    public async Task<IPaginate<GetListWorkExperienceResponse>> GetListAsync(PageRequest pageRequest)
    {
        var workExperience = await _workExperienceDal.GetListAsync(
                include: we => we
                .Include(we => we.City)
                .Include(we => we.Account).ThenInclude(we => we.User),
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize);

        var mappedWorkExperience = _mapper.Map<Paginate<GetListWorkExperienceResponse>>(workExperience);
        return mappedWorkExperience;
    }

    public async Task<GetWorkExperienceResponse> GetByIdAsync(Guid id)
    {
        var workExperience = await _workExperienceDal.GetAsync(
            predicate: we => we.Id == id,
            include: we => we
            .Include(we => we.City)
            .Include(we => we.Account).ThenInclude(we => we.User));
        var mappedWorkExperience = _mapper.Map<GetWorkExperienceResponse>(workExperience);
        return mappedWorkExperience;
    }

    public async Task<UpdatedWorkExperienceResponse> UpdateAsync(UpdateWorkExperienceRequest updateWorkExperienceRequest)
    {
        await _workExperienceBusinessRules.IsExistsWorkExperience(updateWorkExperienceRequest.Id);
        WorkExperience workExperience = _mapper.Map<WorkExperience>(updateWorkExperienceRequest);
        WorkExperience updatedWorkExperience = await _workExperienceDal.UpdateAsync(workExperience);
        UpdatedWorkExperienceResponse updatedWorkExperienceResponse = _mapper.Map<UpdatedWorkExperienceResponse>(updatedWorkExperience);
        return updatedWorkExperienceResponse;
    }

    public async Task<IPaginate<GetListWorkExperienceResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var workExperience = await _workExperienceDal.GetListAsync(
            predicate: we => we.AccountId == accountId,
            include: we => we.Include(we => we.City)
            .Include(we => we.Account).ThenInclude(we => we.User));

        var mappedWorkExperiences = _mapper.Map<Paginate<GetListWorkExperienceResponse>>(workExperience);
        return mappedWorkExperiences;

    }
}
