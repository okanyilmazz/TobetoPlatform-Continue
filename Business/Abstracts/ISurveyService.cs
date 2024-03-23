using Business.Dtos.Requests.SurveyRequests;
using Business.Dtos.Responses.SurveyResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISurveyService
{
    Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest);
    Task<DeletedSurveyResponse> DeleteAsync(Guid id);
    Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest);
    Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetSurveyResponse> GetByIdAsync(Guid id);
}