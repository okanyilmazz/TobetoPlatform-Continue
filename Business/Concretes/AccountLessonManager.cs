using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountLessonRequests;
using Business.Dtos.Responses.AccountLessonResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
namespace Business.Concretes;

public class AccountLessonManager : IAccountLessonService
{
    IAccountLessonDal _accountLessonDal;
    IMapper _mapper;
    AccountLessonBusinessRules _accountLessonBusinessRules;
    public AccountLessonManager(IAccountLessonDal accountLessonDal, IMapper mapper, AccountLessonBusinessRules accountLessonBusinessRules)
    {
        _accountLessonDal = accountLessonDal;
        _mapper = mapper;
        _accountLessonBusinessRules = accountLessonBusinessRules;
    }

    public async Task<CreatedAccountLessonResponse> AddAsync(CreateAccountLessonRequest createAccountLessonRequest)
    {
        var AccountLesson = _mapper.Map<AccountLesson>(createAccountLessonRequest);
        var addedAccountLesson = await _accountLessonDal.AddAsync(AccountLesson);
        var responseAccountLesson = _mapper.Map<CreatedAccountLessonResponse>(addedAccountLesson);
        return responseAccountLesson;
    }

    public async Task<DeletedAccountLessonResponse> DeleteAsync(DeleteAccountLessonRequest deleteAccountLessonRequest)
    {
        await _accountLessonBusinessRules.IsExistsAccountLesson(deleteAccountLessonRequest.Id);
        AccountLesson accountLesson = await _accountLessonDal.GetAsync(predicate: l => l.Id == deleteAccountLessonRequest.Id);
        AccountLesson deletedAccountLesson = await _accountLessonDal.DeleteAsync(accountLesson);
        DeletedAccountLessonResponse deletedAccountLessonResponse = _mapper.Map<DeletedAccountLessonResponse>(deletedAccountLesson);
        return deletedAccountLessonResponse;
    }

    public async Task<GetListAccountLessonResponse> GetByIdAsync(Guid id)
    {
        var AccountLessonListed = await _accountLessonDal.GetAsync(
            predicate: a => a.Id == id,
            include: al => al
            .Include(al => al.Account).ThenInclude(a => a.User)
            .Include(al => al.Lesson));
        var mappedListed = _mapper.Map<GetListAccountLessonResponse>(AccountLessonListed);
        return mappedListed;
    }

    public async Task<IPaginate<GetListAccountLessonResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var accountLessonListed = await _accountLessonDal.GetListAsync(
            predicate: a => a.AccountId == accountId,
            include: al => al
            .Include(al => al.Account).ThenInclude(a => a.User)
            .Include(al => al.Lesson));
        var mappedListed = _mapper.Map<Paginate<GetListAccountLessonResponse>>(accountLessonListed);
        return mappedListed;
    }

    public async Task<GetListAccountLessonResponse> GetByAccountIdAndLessonIdAsync(Guid accountId, Guid lessonId)
    {
        var accountLesson = await _accountLessonDal.GetAsync(
            predicate: a => a.AccountId == accountId && a.LessonId == lessonId,
            include: al => al
            .Include(al => al.Account).ThenInclude(a => a.User)
            .Include(al => al.Lesson));
        var mappedListed = _mapper.Map<GetListAccountLessonResponse>(accountLesson);
        return mappedListed;
    }

    public async Task<IPaginate<GetListAccountLessonResponse>> GetListAsync(PageRequest pageRequest)
    {
        var AccountLessonListed = await _accountLessonDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: al => al
            .Include(al => al.Account).ThenInclude(a => a.User)
            .Include(al => al.Lesson));
        var mappedListed = _mapper.Map<Paginate<GetListAccountLessonResponse>>(AccountLessonListed);
        return mappedListed;
    }

    public async Task<UpdatedAccountLessonResponse> UpdateAsync(UpdateAccountLessonRequest updateAccountLessonRequest)
    {
        await _accountLessonBusinessRules.IsExistsAccountLesson(updateAccountLessonRequest.Id);
        var AccountLesson = _mapper.Map<AccountLesson>(updateAccountLessonRequest);
        var updatedAccountLesson = await _accountLessonDal.UpdateAsync(AccountLesson);
        var responseAccountLesson = _mapper.Map<UpdatedAccountLessonResponse>(updatedAccountLesson);
        return responseAccountLesson;
    }
}