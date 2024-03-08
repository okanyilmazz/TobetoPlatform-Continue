using Business.Dtos.Requests.CompetenceQuestionRequests;
using Business.Dtos.Responses.CompetenceQuestionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceQuestionService
{
    Task<CreatedCompetenceQuestionResponse> AddAsync(CreateCompetenceQuestionRequest createCompetenceQuestionRequest);
    Task<UpdatedCompetenceQuestionResponse> UpdateAsync(UpdateCompetenceQuestionRequest updateCompetenceQuestionRequest);
    Task<DeletedCompetenceQuestionResponse> DeleteAsync(DeleteCompetenceQuestionRequest deleteCompetenceQuestionRequest);
    Task<IPaginate<GetListCompetenceQuestionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCompetenceQuestionResponse> GetByIdAsync(Guid id);
}