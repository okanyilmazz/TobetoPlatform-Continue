using Business.Dtos.Requests.AccountCompetenceTestRequests;
using Business.Dtos.Responses.AccountCompetenceTestResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountCompetenceTestService
{
    Task<CreatedAccountCompetenceTestResponse> AddAsync(CreateAccountCompetenceTestRequest createAccountCompetenceTestRequest);
    Task<UpdatedAccountCompetenceTestResponse> UpdateAsync(UpdateAccountCompetenceTestRequest updateAccountCompetenceTestRequest);
    Task<DeletedAccountCompetenceTestResponse> DeleteAsync(DeleteAccountCompetenceTestRequest deleteAccountCompetenceTestRequest);
    Task<GetAccountCompetenceTestResponse> GetByIdAsync(Guid Id);
    Task<IPaginate<GetListAccountCompetenceTestResponse>> GetListAsync(PageRequest pageRequest);
}