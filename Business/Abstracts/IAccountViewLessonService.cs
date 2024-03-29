﻿using Business.Dtos.Requests.AccountViewLessonRequests;
using Business.Dtos.Responses.AccountViewLessonResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAccountViewLessonService
{
    Task<CreatedAccountViewLessonResponse> AddAsync(CreateAccountViewLessonRequest createAccountViewLessonRequest);
    Task<UpdatedAccountViewLessonResponse> UpdateAsync(UpdateAccountViewLessonRequest updateAccountViewLessonRequest);
    Task<DeletedAccountViewLessonResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAccountViewLessonResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListAccountViewLessonResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListAccountViewLessonResponse>> GetByLessonIdAsync(Guid lessonId);
    Task<GetAccountViewLessonResponse> GetByIdAsync(Guid id);
    Task<GetAccountViewLessonResponse> GetByAccountIdAndLessonIdAsync(Guid accountId,Guid lessonId);
}
