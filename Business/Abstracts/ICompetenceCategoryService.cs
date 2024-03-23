using Business.Dtos.Requests.CompetenceRequests;
using Business.Dtos.Responses.CompetenceResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICompetenceCategoryService
{
    Task<CreatedCompetenceCategoryResponse> AddAsync(CreateCompetenceCategoryRequest createCompetenceRequest);
    Task<UpdatedCompetenceCategoryResponse> UpdateAsync(UpdateCompetenceCategoryRequest updateCompetenceRequest);
    Task<DeletedCompetenceCategoryResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListCompetenceCategoryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCompetenceCategoryResponse> GetByIdAsync(Guid id);
}