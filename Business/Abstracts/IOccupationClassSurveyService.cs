using Business.Dtos.Requests.OccupationClassSurveyRequests;
using Business.Dtos.Responses.OccupationClassSurveyResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IOccupationClassSurveyService
    {
        Task<CreatedOccupationClassSurveyResponse> AddAsync(CreateOccupationClassSurveyRequest createOccupationClassSurveyRequest);
        Task<UpdatedOccupationClassSurveyResponse> UpdateAsync(UpdateOccupationClassSurveyRequest updateOccupationClassSurveyRequest);
        Task<DeletedOccupationClassSurveyResponse> DeleteAsync(DeleteOccupationClassSurveyRequest deleteOccupationClassSurveyRequest);
        Task<IPaginate<GetListOccupationClassSurveyResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListOccupationClassSurveyResponse> GetByIdAsync(Guid Id);
    }
}
