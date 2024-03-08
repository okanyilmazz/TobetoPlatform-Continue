using Business.Dtos.Requests.CompetenceTestRequests;
using Business.Dtos.Responses.CompetenceTestResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceTestService
{
    Task<CreatedCompetenceTestResponse> AddAsync(CreateCompetenceTestRequest createCompetenceTestRequest);
    Task<UpdatedCompetenceTestResponse> UpdateAsync(UpdateCompetenceTestRequest updateCompetenceTestRequest);
    Task<DeletedCompetenceTestResponse> DeleteAsync(DeleteCompetenceTestRequest deleteCompetenceTestRequest);
    Task<IPaginate<GetListCompetenceTestResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCompetenceTestResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListCompetenceTestResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest);
}
