using Business.Dtos.Requests.CompetenceTestQuestionRequests;
using Business.Dtos.Responses.CompetenceTestQuestionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceTestQuestionService
{
    Task<CreatedCompetenceTestQuestionResponse> AddAsync(CreateCompetenceTestQuestionRequest createCompetenceTestQuestionRequest);
    Task<UpdatedCompetenceTestQuestionResponse> UpdateAsync(UpdateCompetenceTestQuestionRequest updateCompetenceTestQuestionRequest);
    Task<DeletedCompetenceTestQuestionResponse> DeleteAsync(DeleteCompetenceTestQuestionRequest deleteCompetenceTestQuestionRequest);
    Task<IPaginate<GetListCompetenceTestQuestionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCompetenceTestQuestionResponse> GetByIdAsync(Guid id);
}
