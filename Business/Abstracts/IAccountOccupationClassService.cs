﻿using Business.Dtos.Requests.AccountOccupationClassRequests;
using Business.Dtos.Responses.AccountOccupationClassResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountOccupationClassService
{
    Task<CreatedAccountOccupationClassResponse> AddAsync(CreateAccountOccupationClassRequest createAccountOccupationClassRequest);
    Task<UpdatedAccountOccupationClassResponse> UpdateAsync(UpdateAccountOccupationClassRequest updateAccountOccupationClassRequest);
    Task<DeletedAccountOccupationClassResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountOccupationClassResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAccountOccupationClassResponse> GetByIdAsync(Guid id);
    Task<GetAccountOccupationClassResponse> GetByAccountIdAndOccupationClassId(Guid accountId, Guid occupationClassId);

}