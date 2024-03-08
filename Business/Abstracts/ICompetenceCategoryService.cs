using Business.Dtos.Requests.CompetenceRequests;
using Business.Dtos.Responses.CompetenceResponses;
using Business.Dtos.Responses.ExamResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceCategoryService
{
    Task<CreatedCompetenceCategoryResponse> AddAsync(CreateCompetenceCategoryRequest createCompetenceRequest);
    Task<UpdatedCompetenceCategoryResponse> UpdateAsync(UpdateCompetenceCategoryRequest updateCompetenceRequest);
    Task<DeletedCompetenceCategoryResponse> DeleteAsync(DeleteCompetenceCategoryRequest deleteCompetenceRequest);
    Task<IPaginate<GetListCompetenceCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCompetenceCategoryResponse> GetByIdAsync(Guid id);
}