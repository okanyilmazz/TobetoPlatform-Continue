using Business.Dtos.Requests.AccountUniversityRequests;
using Business.Dtos.Responses.AccountSocialMediaResponses;
using Business.Dtos.Responses.AccountUniversityResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountUniversityService
{
    Task<CreatedAccountUniversityResponse> AddAsync(CreateAccountUniversityRequest createAccountUniversityRequest);
    Task<UpdatedAccountUniversityResponse> UpdateAsync(UpdateAccountUniversityRequest updateAccountUniversityRequest);
    Task<DeletedAccountUniversityResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountUniversityResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAccountUniversityResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListAccountUniversityResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest);

}