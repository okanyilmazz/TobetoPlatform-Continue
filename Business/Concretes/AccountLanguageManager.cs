using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountLanguageRequests;
using Business.Dtos.Responses.AccountLanguageResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
namespace Business.Concretes;

public class AccountLanguageManager : IAccountLanguageService
{
    IAccountLanguageDal _accountLanguageDal;
    IMapper _mapper;
    AccountLanguageBusinessRules _accountLanguageBusinessRules;
    public AccountLanguageManager(IAccountLanguageDal accountLanguageDal, IMapper mapper, AccountLanguageBusinessRules accountLanguageBusinessRules)
    {
        _accountLanguageDal = accountLanguageDal;
        _mapper = mapper;
        _accountLanguageBusinessRules = accountLanguageBusinessRules;
    }

    public async Task<CreatedAccountLanguageResponse> AddAsync(CreateAccountLanguageRequest createAccountLanguageRequest)
    {
        var AccountLanguage = _mapper.Map<AccountLanguage>(createAccountLanguageRequest);
        var addedAccountLanguage = await _accountLanguageDal.AddAsync(AccountLanguage);
        var responseAccountLanguage = _mapper.Map<CreatedAccountLanguageResponse>(addedAccountLanguage);
        return responseAccountLanguage;
    }

    public async Task<DeletedAccountLanguageResponse> DeleteAsync(Guid id)
    {
        await _accountLanguageBusinessRules.IsExistsAccountLanguage(id);
        AccountLanguage accountLanguage = await _accountLanguageDal.GetAsync(predicate: a => a.Id == id);
        var deletedAccountLanguage = await _accountLanguageDal.DeleteAsync(accountLanguage);
        var responseAccountLanguage = _mapper.Map<DeletedAccountLanguageResponse>(deletedAccountLanguage);
        return responseAccountLanguage;
    }

    public async Task<GetAccountLanguageResponse> GetByIdAsync(Guid id)
    {
        var AccountLanguageListed = await _accountLanguageDal.GetAsync(
            predicate: a => a.Id == id,
            include: al => al
            .Include(al => al.Language)
            .Include(al => al.LanguageLevel)
            .Include(al => al.Account).ThenInclude(a => a.User));
        var mappedListed = _mapper.Map<GetAccountLanguageResponse>(AccountLanguageListed);
        return mappedListed;
    }

    public async Task<IPaginate<GetListAccountLanguageResponse>> GetByAccountIdAsync(Guid accountId)
    { 
        var accountLanguageListed = await _accountLanguageDal.GetListAsync(
            predicate: a => a.AccountId == accountId,
            include: al => al
            .Include(al => al.Language)
            .Include(al => al.LanguageLevel)
            .Include(al => al.Account).ThenInclude(a => a.User));
        var mappedListed = _mapper.Map<Paginate<GetListAccountLanguageResponse>>(accountLanguageListed);
        return mappedListed;
    }

    public async Task<IPaginate<GetListAccountLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var AccountLanguageListed = await _accountLanguageDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: al => al
            .Include(al => al.Language)
            .Include(al => al.LanguageLevel)
            .Include(al => al.Account).ThenInclude(a => a.User));
        var mappedListed = _mapper.Map<Paginate<GetListAccountLanguageResponse>>(AccountLanguageListed);
        return mappedListed;
    }

    public async Task<UpdatedAccountLanguageResponse> UpdateAsync(UpdateAccountLanguageRequest updateAccountLanguageRequest)
    {
        await _accountLanguageBusinessRules.IsExistsAccountLanguage(updateAccountLanguageRequest.Id);
        var AccountLanguage = _mapper.Map<AccountLanguage>(updateAccountLanguageRequest);
        var updatedAccountLanguage = await _accountLanguageDal.UpdateAsync(AccountLanguage);
        var responseAccountLanguage = _mapper.Map<UpdatedAccountLanguageResponse>(updatedAccountLanguage);
        return responseAccountLanguage;
    }
}