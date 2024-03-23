using Business.Dtos.Requests.AccountFavoriteEducationProgramRequests;
using Business.Dtos.Responses.AccountFavoriteEducationProgramResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountFavoriteEducationProgramService
{
    Task<CreatedAccountFavoriteEducationProgramResponse> AddAsync(CreateAccountFavoriteEducationProgramRequest createAccountFavoriteEducationProgramRequest);
    Task<UpdatedAccountFavoriteEducationProgramResponse> UpdateAsync(UpdateAccountFavoriteEducationProgramRequest updateAccountFavoriteEducationProgramRequest);
    Task<DeletedAccountFavoriteEducationProgramResponse> DeleteAsync(Guid id);
    Task<DeletedAccountFavoriteEducationProgramResponse> DeleteByAccountIdAndEducationProgramIdAsync(DeleteAccountFavoriteEducationProgramRequest deleteAccountFavoriteEducationProgramRequest);
    Task<IPaginate<GetListAccountFavoriteEducationProgramResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountFavoriteEducationProgramResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListAccountFavoriteEducationProgramResponse>> GetByEducationProgramIdAsync(Guid educationProgramId);
    Task<GetAccountFavoriteEducationProgramResponse> GetByIdAsync(Guid id);
    Task<GetAccountFavoriteEducationProgramResponse> GetByAccountIdAndEducationProgramIdAsync(Guid accountId, Guid educationProgramId);
}