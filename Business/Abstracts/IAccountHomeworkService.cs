﻿using Business.Dtos.Requests.AccountHomeworkRequests;
using Business.Dtos.Responses.AccountHomeworkResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountHomeworkService
{
    Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest);
    Task<UpdatedAccountHomeworkResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest);
    Task<DeletedAccountHomeworkResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAccountHomeworkResponse> GetByIdAsync(Guid id);
}
