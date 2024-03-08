using Business.Dtos.Requests.LanguageRequests;
using Business.Dtos.Responses.LanguageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILanguageService
{
    Task<CreatedLanguageResponse> AddAsync(CreateLanguageRequest createLanguageRequest);
    Task<UpdatedLanguageResponse> UpdateAsync(UpdateLanguageRequest updateLanguageRequest);
    Task<DeletedLanguageResponse> DeleteAsync(DeleteLanguageRequest deleteLanguageRequest);
    Task<IPaginate<GetListLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListLanguageResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListLanguageResponse>> GetByAccountIdAsync(Guid id);
}
