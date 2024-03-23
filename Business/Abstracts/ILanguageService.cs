using Business.Dtos.Requests.LanguageRequests;
using Business.Dtos.Responses.LanguageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILanguageService
{
    Task<CreatedLanguageResponse> AddAsync(CreateLanguageRequest createLanguageRequest);
    Task<UpdatedLanguageResponse> UpdateAsync(UpdateLanguageRequest updateLanguageRequest);
    Task<DeletedLanguageResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetLanguageResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListLanguageResponse>> GetByAccountIdAsync(Guid id);
}
