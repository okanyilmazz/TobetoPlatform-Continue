using Business.Dtos.Requests.ProgrammingLanguageRequests;
using Business.Dtos.Responses.ProgrammingLanguageResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IProgrammingLanguageService
{
    Task<CreatedProgrammingLanguageResponse> AddAsync(CreateProgrammingLanguageRequest createProgrammingLanguageRequest);
    Task<UpdatedProgrammingLanguageResponse> UpdateAsync(UpdateProgrammingLanguageRequest updateProgrammingLanguageRequest);
    Task<DeletedProgrammingLanguageResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListProgrammingLanguageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetProgrammingLanguageResponse> GetByIdAsync(Guid id);
}
