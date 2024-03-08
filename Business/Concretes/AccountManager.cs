using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Responses.AccountResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Business.Concretes;

public class AccountManager : IAccountService
{

    IAccountDal _accountDal;
    IMapper _mapper;
    AccountBusinessRules _accountBusinessRules;

    public AccountManager(IAccountDal accountDal, IMapper mapper, AccountBusinessRules accountBusinessRules)
    {
        _accountDal = accountDal;
        _mapper = mapper;
        _accountBusinessRules = accountBusinessRules;
    }

    public async Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest)
    {
        await _accountBusinessRules.IsExistsNationalId(createAccountRequest.NationalId);
        await _accountBusinessRules.IsExistsPhoneNumber(createAccountRequest.PhoneNumber);

        Account account = _mapper.Map<Account>(createAccountRequest);
        Account addedAccount = await _accountDal.AddAsync(account);
        CreatedAccountResponse createdAccountResponse = _mapper.Map<CreatedAccountResponse>(addedAccount);
        return createdAccountResponse;
    }

    public async Task<DeletedAccountResponse> DeleteAsync(DeleteAccountRequest deleteAccountRequest)
    {
        await _accountBusinessRules.IsExistsAccount(deleteAccountRequest.Id);
        Account account = await _accountDal.GetAsync(predicate: l => l.Id == deleteAccountRequest.Id);
        Account deletedAccount = await _accountDal.DeleteAsync(account);
        DeletedAccountResponse deletedAccountResponse = _mapper.Map<DeletedAccountResponse>(deletedAccount);
        return deletedAccountResponse;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetBySessionIdAsync(Guid sessionId)
    {
        var accountList = await _accountDal.GetListAsync(
             include: e => e.Include(s => s.AccountSessions).ThenInclude(ask => ask.Session));

        var filteredAccounts = accountList
            .Items.Where(e => e.AccountSessions.Any(s => s.SessionId == sessionId)).ToList();

        var mappedAccounts = _mapper.Map<Paginate<GetListAccountResponse>>(filteredAccounts);
        return mappedAccounts;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetListAsync(PageRequest pageRequest)
    {
        var account = await _accountDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: a => a
            .Include(a => a.User)
            .Include(a=> a.AccountOccupationClasses).ThenInclude(aoc => aoc.OccupationClass));
        var mappedAccountSession = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccountSession;
    }

    public async Task<GetAccountResponse> GetByIdAsync(Guid id)
    {
        var account = await _accountDal.GetAsync(
            predicate: a => a.Id == id,
            include: a => a
             .Include(a => a.User)
            .Include(a => a.AccountOccupationClasses).ThenInclude(aoc => aoc.OccupationClass));
        var mappedAccount = _mapper.Map<GetAccountResponse>(account);
        return mappedAccount;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetByLessonIdForLikeAsync(Guid lessonId, PageRequest pageRequest)
    {
        var account = await _accountDal.GetListAsync(
            predicate: a => a.LessonLikes.Any(ll => ll.LessonId == lessonId),
            size: pageRequest.PageSize,
            index: pageRequest.PageIndex,
            include: a => a
            .Include(a => a.LessonLikes)
            .Include(a => a.User));
        var mappedAccount = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccount;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetByEducationProgramIdForLikeAsync(Guid educationProgramId, PageRequest pageRequest)
    {
        var account = await _accountDal.GetListAsync(
            predicate: a => a.EducationProgramLikes.Any(epl => epl.EducationProgramId == educationProgramId),
            size: pageRequest.PageSize,
            index: pageRequest.PageIndex,
            include: a => a
            .Include(a => a.EducationProgramLikes)
            .Include(a => a.User));
        var mappedAccount = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccount;
    }

    public async Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest)
    {
        await _accountBusinessRules.IsExistsAccount(updateAccountRequest.Id);

        Account account = _mapper.Map<Account>(updateAccountRequest);
        Account updatedAccount = await _accountDal.UpdateAsync(account);
        UpdatedAccountResponse updatedAccountResponse = _mapper.Map<UpdatedAccountResponse>(updatedAccount);
        return updatedAccountResponse;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetByEducationProgramIAsync(Guid educationProgramId)
    {
        var account = await _accountDal.GetListAsync(
            predicate: a => a.AccountEducationPrograms.Any(epl => epl.EducationProgramId == educationProgramId),
             include: a => a
            .Include(a => a.AccountEducationPrograms)
            .ThenInclude(a => a.EducationProgram));
        var mappedAccount = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccount;
    }
}
