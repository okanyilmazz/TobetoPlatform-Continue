using Business.Dtos.Requests.UniversityResquests;
using Business.Dtos.Responses.UniversityResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IUniversityService
{
    Task<CreatedUniversityResponse> AddAsync(CreateUniversityRequest createUniversityRequest);
    Task<UpdatedUniversityResponse> UpdateAsync(UpdateUniversityRequest updateUniversityRequest);
    Task<DeletedUniversityResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListUniversityResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetUniversityResponse> GetByIdAsync(Guid id);
}