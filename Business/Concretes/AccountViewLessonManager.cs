using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountViewLessonRequest;
using Business.Dtos.Responses.AccountViewLessonResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountViewLessonManager : IAccountViewLessonService
{
    IAccountViewLessonDal _accountViewLessonDal;
    IMapper _mapper;
    AccountViewLessonBusinessRules _accountViewLessonBusinessRules;

    public AccountViewLessonManager(IAccountViewLessonDal accountViewLessonDal, IMapper mapper, AccountViewLessonBusinessRules accountViewLessonBusinessRules)
    {
        _accountViewLessonDal = accountViewLessonDal;
        _mapper = mapper;
        _accountViewLessonBusinessRules = accountViewLessonBusinessRules;
    }
    public async Task<CreatedAccountViewLessonResponse> AddAsync(CreateAccountViewLessonRequest createAccountViewLessonRequests)
    {
        AccountViewLesson accountViewLesson = _mapper.Map<AccountViewLesson>(createAccountViewLessonRequests);
        AccountViewLesson addedAccountViewLesson = await _accountViewLessonDal.AddAsync(accountViewLesson);
        CreatedAccountViewLessonResponse createdAccountViewLessonResponse = _mapper.Map<CreatedAccountViewLessonResponse>(addedAccountViewLesson);
        return createdAccountViewLessonResponse;
    }


    public async Task<DeletedAccountViewLessonResponse> DeleteAsync(DeleteAccountViewLessonRequest deleteAccountViewLessonRequest)
    {
        await _accountViewLessonBusinessRules.IsExistsAccountViewLesson(deleteAccountViewLessonRequest.Id);
        AccountViewLesson accountViewLesson = await _accountViewLessonDal.GetAsync(predicate: a => a.Id == deleteAccountViewLessonRequest.Id);
        AccountViewLesson deletedAccountViewLesson = await _accountViewLessonDal.DeleteAsync(accountViewLesson);
        DeletedAccountViewLessonResponse deletedAccountViewLessonResponse = _mapper.Map<DeletedAccountViewLessonResponse>(deletedAccountViewLesson);
        return deletedAccountViewLessonResponse;
    }

    public async Task<GetAccountViewLessonResponse> GetByIdAsync(Guid id)
    {
        var accountViewLesson = await _accountViewLessonDal.GetAsync(
            predicate: a => a.Id == id,
            include: awl => awl.
            Include(awl => awl.Lesson)
            .Include(awl => awl.Account).ThenInclude(a => a.User));
        var mappedAccountViewLesson = _mapper.Map<GetAccountViewLessonResponse>(accountViewLesson);
        return mappedAccountViewLesson;
    }

    public async Task<IPaginate<GetListAccountViewLessonResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var accountViewLesson = await _accountViewLessonDal.GetListAsync(
            predicate: a => a.AccountId == accountId,
            include: awl => awl.
            Include(awl => awl.Lesson)
            .Include(awl => awl.Account).ThenInclude(a => a.User));
        var mappedAccountViewLesson = _mapper.Map<Paginate<GetListAccountViewLessonResponse>>(accountViewLesson);
        return mappedAccountViewLesson;
    }

    public async Task<IPaginate<GetListAccountViewLessonResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountViewLessons = await _accountViewLessonDal.GetListAsync(
            include: awl => awl.
            Include(awl => awl.Lesson)
            .Include(awl => awl.Account).ThenInclude(a => a.User));

        var mappedAccountViewLessons = _mapper.Map<Paginate<GetListAccountViewLessonResponse>>(accountViewLessons);
        return mappedAccountViewLessons;
    }

    public async Task<UpdatedAccountViewLessonResponse> UpdateAsync(UpdateAccountViewLessonRequest updateAccountViewLessonRequest)
    {
        await _accountViewLessonBusinessRules.IsExistsAccountViewLesson(updateAccountViewLessonRequest.Id);
        AccountViewLesson accountViewLesson = _mapper.Map<AccountViewLesson>(updateAccountViewLessonRequest);
        AccountViewLesson updatedAccountViewLesson = await _accountViewLessonDal.UpdateAsync(accountViewLesson);
        UpdatedAccountViewLessonResponse updatedAccountViewLessonResponse = _mapper.Map<UpdatedAccountViewLessonResponse>(updatedAccountViewLesson);
        return updatedAccountViewLessonResponse;
    }


    public async Task<IPaginate<GetListAccountViewLessonResponse>> GetByLessonIdAsync(Guid lessonId)
    {
        var accountViewLesson = await _accountViewLessonDal.GetListAsync(
          predicate: a => a.LessonId == lessonId,
          include: awl => awl.
          Include(awl => awl.Lesson)
          .Include(awl => awl.Account).ThenInclude(a => a.User));
        var mappedAccountViewLesson = _mapper.Map<Paginate<GetListAccountViewLessonResponse>>(accountViewLesson);
        return mappedAccountViewLesson;
    }

    public async Task<GetAccountViewLessonResponse> GetByAccountIdAndLessonIdAsync(Guid accountId, Guid lessonId)
    {
        var accountViewLesson = await _accountViewLessonDal.GetAsync(
         predicate: a => a.LessonId == lessonId && a.AccountId == accountId,
         include: awl => awl.
         Include(awl => awl.Lesson)
         .Include(awl => awl.Account).ThenInclude(a => a.User));
        var mappedAccountViewLesson = _mapper.Map<GetAccountViewLessonResponse>(accountViewLesson);
        return mappedAccountViewLesson;
    }
}