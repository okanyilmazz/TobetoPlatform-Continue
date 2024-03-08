using Business.Dtos.Requests.SurveyRequests;
using Business.Dtos.Responses.SurveyResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ISurveyService
    {
        Task<CreatedSurveyResponse> AddAsync(CreateSurveyRequest createSurveyRequest);
        Task<DeletedSurveyResponse> DeleteAsync(DeleteSurveyRequest deleteSurveyRequest);
        Task<UpdatedSurveyResponse> UpdateAsync(UpdateSurveyRequest updateSurveyRequest);
        Task<IPaginate<GetListSurveyResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListSurveyResponse> GetByIdAsync(Guid id);

    }
}
