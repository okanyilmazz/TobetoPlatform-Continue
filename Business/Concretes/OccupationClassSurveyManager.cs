using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.OccupationClassSurveyRequests;
using Business.Dtos.Responses.OccupationClassSurveyResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class OccupationClassSurveyManager : IOccupationClassSurveyService
{

    IOccupationClassSurveyDal _occupationClassSurveyDal;
    IMapper _mapper;
    OccupationClassSurveyBusinessRules _occupationClassSurveyBusinessRules;

    public OccupationClassSurveyManager(IOccupationClassSurveyDal occupationClassSurveyDal, IMapper mapper, OccupationClassSurveyBusinessRules occupationClassSurveyBusinessRules)
    {
        _occupationClassSurveyDal = occupationClassSurveyDal;
        _mapper = mapper;
        _occupationClassSurveyBusinessRules = occupationClassSurveyBusinessRules;
    }

    public async Task<CreatedOccupationClassSurveyResponse> AddAsync(CreateOccupationClassSurveyRequest createOccupationClassSurveyRequest)
    {
        OccupationClassSurvey OccupationClassSurvey = _mapper.Map<OccupationClassSurvey>(createOccupationClassSurveyRequest);
        OccupationClassSurvey createdOccupationClassSurvey = await _occupationClassSurveyDal.AddAsync(OccupationClassSurvey);
        CreatedOccupationClassSurveyResponse createdOccupationClassSurveyResponse = _mapper.Map<CreatedOccupationClassSurveyResponse>(createdOccupationClassSurvey);
        return createdOccupationClassSurveyResponse;
    }

    public async Task<DeletedOccupationClassSurveyResponse> DeleteAsync(Guid id)
    {
        await _occupationClassSurveyBusinessRules.IsExistsOccupationClassSurvey(id);
        OccupationClassSurvey occupationClassSurvey = await _occupationClassSurveyDal.GetAsync(predicate: a => a.Id == id);
        OccupationClassSurvey deletedOccupationClassSurvey = await _occupationClassSurveyDal.DeleteAsync(occupationClassSurvey);
        DeletedOccupationClassSurveyResponse deletedOccupationClassSurveyResponse = _mapper.Map<DeletedOccupationClassSurveyResponse>(deletedOccupationClassSurvey);
        return deletedOccupationClassSurveyResponse;
    }

    public async Task<GetOccupationClassSurveyResponse> GetByIdAsync(Guid id)
    {
        var occupationClassSurvey = await _occupationClassSurveyDal.GetAsync(
            predicate: o => o.Id == id,
            include: ocs => ocs.
            Include(ocs => ocs.OccupationClass)
            .Include(ocs => ocs.Survey));
        var mappedoccupationClassSurvey = _mapper.Map<GetOccupationClassSurveyResponse>(occupationClassSurvey);
        return mappedoccupationClassSurvey;
    }

    public async Task<IPaginate<GetListOccupationClassSurveyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var OccupationClassSurvey = await _occupationClassSurveyDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
             include: ocs => ocs.
            Include(ocs => ocs.OccupationClass)
            .Include(ocs => ocs.Survey));
        var mappedOccupationClassSurvey = _mapper.Map<Paginate<GetListOccupationClassSurveyResponse>>(OccupationClassSurvey);
        return mappedOccupationClassSurvey;
    }

    public async Task<UpdatedOccupationClassSurveyResponse> UpdateAsync(UpdateOccupationClassSurveyRequest updateOccupationClassSurveyRequest)
    {
        await _occupationClassSurveyBusinessRules.IsExistsOccupationClassSurvey(updateOccupationClassSurveyRequest.Id);
        OccupationClassSurvey OccupationClassSurvey = _mapper.Map<OccupationClassSurvey>(updateOccupationClassSurveyRequest);
        OccupationClassSurvey updatedOccupationClassSurvey = await _occupationClassSurveyDal.UpdateAsync(OccupationClassSurvey);
        UpdatedOccupationClassSurveyResponse updatedOccupationClassSurveyResponse = _mapper.Map<UpdatedOccupationClassSurveyResponse>(updatedOccupationClassSurvey);
        return updatedOccupationClassSurveyResponse;
    }
}
