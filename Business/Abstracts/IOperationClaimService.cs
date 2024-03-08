using Business.Dtos.Requests.OperationClaimRequests;
using Business.Dtos.Responses.OperationClaimResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IOperationClaimService
{
    Task<CreatedOperationClaimResponse> AddAsync(CreateOperationClaimRequest createOperationClaimRequest);
    Task<UpdatedOperationClaimResponse> UpdateAsync(UpdateOperationClaimRequest updateOperationClaimRequest);
    Task<DeletedOperationClaimResponse> DeleteAsync(DeleteOperationClaimRequest deleteOperationClaimRequest);
    Task<IPaginate<GetListOperationClaimResponse>> GetListAsync(PageRequest pageRequest);
    Task<List<GetListOperationClaimResponse>> GetByUserIdAsync(Guid userId);
    Task<GetOperationClaimResponse> GetByRoleName(string roleName);
}