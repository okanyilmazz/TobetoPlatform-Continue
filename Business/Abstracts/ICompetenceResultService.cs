using Business.Dtos.Requests.CompetenceResultRequests;
using Business.Dtos.Responses.CompetenceResultResponses;
using Business.Dtos.Responses.ExamResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceResultService
{
    Task<CreatedCompetenceResultResponse> AddAsync(CreateCompetenceResultRequest createCompetenceResultRequest);
    Task<UpdatedCompetenceResultResponse> UpdateAsync(UpdateCompetenceResultRequest updateCompetenceResultRequest);
    Task<DeletedCompetenceResultResponse> DeleteAsync(DeleteCompetenceResultRequest deleteCompetenceResultRequest);
    Task<IPaginate<GetListCompetenceResultResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCompetenceResultResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListCompetenceResultResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest);
}