using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.SurveyRequests;
using Business.Dtos.Responses.SurveyResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class SurveyManager : ISurveyService
{
    ISurveyDal _surveyDal;
    IMapper _mapper;
    SurveyBusinessRules _surveyBusinessRules;

    public SurveyManager(ISurveyDal surveyDal, IMapper mapper, SurveyBusinessRules surveyBusinessRules)
    {
        _surveyDal = surveyDal;
        _mapper = mapper;
        _surveyBusinessRules = surveyBusinessRules;
    }

    public async Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest)
    {
        Survey survey = _mapper.Map<Survey>(createSurveyRequest);
        Survey createdSurvey = await _surveyDal.AddAsync(survey);
        CreatedSurveyResponse createdSurveyResponse = _mapper.Map<CreatedSurveyResponse>(createdSurvey);
        return createdSurveyResponse;
    }

    public async Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest)
    {
        await _surveyBusinessRules.IsExistsSurvey(deleteSurveyRequest.Id);
        Survey survey = await _surveyDal.GetAsync(predicate: o => o.Id == deleteSurveyRequest.Id);
        Survey deletedSurvey = await _surveyDal.DeleteAsync(survey);
        DeletedSurveyResponse deletedSurveyResponse = _mapper.Map<DeletedSurveyResponse>(deletedSurvey);
        return deletedSurveyResponse;
    }

    public async Task<GetListSurveyResponse> GetByIdAsync(Guid id)
    {
        var survey = await _surveyDal.GetAsync(s => s.Id == id);
        var mappedSurvey = _mapper.Map<GetListSurveyResponse>(survey);
        return mappedSurvey;
    }

    public async Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest)
    {
        var surveys = await _surveyDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedSurveys = _mapper.Map<Paginate<GetListSurveyResponse>>(surveys);
        return mappedSurveys;
    }

    public async Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest)
    {
        await _surveyBusinessRules.IsExistsSurvey(updateSurveyRequest.Id);
        Survey survey = _mapper.Map<Survey>(updateSurveyRequest);
        Survey updatedSurvey = await _surveyDal.UpdateAsync(survey);
        UpdatedSurveyResponse updatedSurveyResponse = _mapper.Map<UpdatedSurveyResponse>(updatedSurvey);
        return updatedSurveyResponse;
    }
}
