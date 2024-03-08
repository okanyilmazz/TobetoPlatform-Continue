using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ActivityMapRequests;
using Business.Dtos.Responses.ActivityMapResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ActivityMapManager : IActivityMapService
{
    IActivityMapDal _activityMapDal;
    IMapper _mapper;
    ActivityMapBusinessRules _activityMapBusinessRules;

    public ActivityMapManager(IActivityMapDal activityMapDal,
        IMapper mapper,
        ActivityMapBusinessRules activityMapBusinessRules)
    {
        _activityMapDal = activityMapDal;
        _mapper = mapper;
        _activityMapBusinessRules = activityMapBusinessRules;
    }

    public async Task<CreatedActivityMapResponse> AddAsync(CreateActivityMapRequest createActivityMapRequest)
    {
        ActivityMap activityMap = _mapper.Map<ActivityMap>(createActivityMapRequest);
        ActivityMap createdActivityMap = await _activityMapDal.AddAsync(activityMap);
        CreatedActivityMapResponse createdActivityMapResponse = _mapper.Map<CreatedActivityMapResponse>(createdActivityMap);
        return createdActivityMapResponse;
    }

    public async Task<DeletedActivityMapResponse> DeleteAsync(DeleteActivityMapRequest deleteActivityMapRequest)
    {
        await _activityMapBusinessRules.IsExistsActivityMap(deleteActivityMapRequest.Id.Value);
        ActivityMap activityMap = await _activityMapDal.GetAsync(predicate: l => l.Id == deleteActivityMapRequest.Id);
        ActivityMap deletedActivityMap = await _activityMapDal.DeleteAsync(activityMap);
        DeletedActivityMapResponse deletedActivityMapResponse = _mapper.Map<DeletedActivityMapResponse>(deletedActivityMap);
        return deletedActivityMapResponse;
    }

    public async Task<IPaginate<GetListActivityMapResponse>> GetByAccountIdAsync(Guid id)
    {
        var activityMapList = await _activityMapDal.GetListAsync(
        include: b => b.Include(b => b.Accounts)
                      .ThenInclude(ab => ab.Account));

        var filteredactivityMaps = activityMapList
            .Items.Where(b => b.Accounts.Any(ab => ab.AccountId == id)).ToList();

        var mappedactivityMaps = _mapper.Map<Paginate<GetListActivityMapResponse>>(filteredactivityMaps);
        return mappedactivityMaps;
    }

    public async Task<GetListActivityMapResponse> GetByIdAsync(Guid Id)
    {
        var activityMap = await _activityMapDal.GetAsync(
            predicate: b => b.Id == Id);
        var mappedActivityMap = _mapper.Map<GetListActivityMapResponse>(activityMap);
        return mappedActivityMap;
    }

    public async Task<IPaginate<GetListActivityMapResponse>> GetListAsync(PageRequest pageRequest)
    {
        var ActivityMaps = await _activityMapDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedActivityMap = _mapper.Map<Paginate<GetListActivityMapResponse>>(ActivityMaps);
        return mappedActivityMap;
    }

    public async Task<UpdatedActivityMapResponse> UpdateAsync(UpdateActivityMapRequest updateActivityMapRequest)
    {
        await _activityMapBusinessRules.IsExistsActivityMap(updateActivityMapRequest.Id.Value);
        ActivityMap activityMap = _mapper.Map<ActivityMap>(updateActivityMapRequest);
        ActivityMap updatedActivityMap = await _activityMapDal.UpdateAsync(activityMap);
        UpdatedActivityMapResponse updatedActivityMapResponse = _mapper.Map<UpdatedActivityMapResponse>(updatedActivityMap);
        return updatedActivityMapResponse;
    }
}

