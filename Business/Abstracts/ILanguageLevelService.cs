using Business.Dtos.Requests.LanguageLevelRequests;
using Business.Dtos.Responses.LanguageLevelResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILanguageLevelService
{
    Task<IPaginate<GetListLanguageLevelResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedLanguageLevelResponse> AddAsync(CreateLanguageLevelRequest createLanguageLevelRequest);
    Task<UpdatedLanguageLevelResponse> UpdateAsync(UpdateLanguageLevelRequest updateLanguageLevelRequest);
    Task<DeletedLanguageLevelResponse> DeleteAsync(Guid id);
    Task<GetLanguageLevelResponse> GetByIdAsync(Guid id);
}
