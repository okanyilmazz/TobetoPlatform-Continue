using Business.Dtos.Requests.OccupationClassSurveyRequests;
using Business.Dtos.Responses.OccupationClassSurveyResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IOccupationClassSurveyService
{
    Task<CreatedOccupationClassSurveyResponse> AddAsync(CreateOccupationClassSurveyRequest createOccupationClassSurveyRequest);
    Task<UpdatedOccupationClassSurveyResponse> UpdateAsync(UpdateOccupationClassSurveyRequest updateOccupationClassSurveyRequest);
    Task<DeletedOccupationClassSurveyResponse> DeleteAsync(DeleteOccupationClassSurveyRequest deleteOccupationClassSurveyRequest);
    Task<IPaginate<GetListOccupationClassSurveyResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetOccupationClassSurveyResponse> GetByIdAsync(Guid Id);
}
