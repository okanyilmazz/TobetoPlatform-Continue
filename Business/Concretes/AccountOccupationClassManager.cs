using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountOccupationClassRequests;
using Business.Dtos.Responses.AccountOccupationClassResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountOccupationClassManager : IAccountOccupationClassService
{
    IAccountOccupationClassDal _accountOccupationClassDal;
    IMapper _mapper;
    AccountOccupationClassBusinessRules _accountOccupationClassRules;

    public AccountOccupationClassManager(IAccountOccupationClassDal accountOccupationClassDal, IMapper mapper, AccountOccupationClassBusinessRules accountOccupationClassRules)
    {
        _accountOccupationClassDal = accountOccupationClassDal;
        _mapper = mapper;
        _accountOccupationClassRules = accountOccupationClassRules;
    }

    public async Task<CreatedAccountOccupationClassResponse> AddAsync(CreateAccountOccupationClassRequest createAccountOccupationClassRequest)
    {
        AccountOccupationClass accountOccupationClass = _mapper.Map<AccountOccupationClass>(createAccountOccupationClassRequest);
        AccountOccupationClass addedAccountOccupationClass = await _accountOccupationClassDal.AddAsync(accountOccupationClass);
        var mappedAccountOccupationClass = _mapper.Map<CreatedAccountOccupationClassResponse>(addedAccountOccupationClass);
        return mappedAccountOccupationClass;
    }

    public async Task<DeletedAccountOccupationClassResponse> DeleteAsync(DeleteAccountOccupationClassRequest deleteAccountOccupationClassRequest)
    {
        await _accountOccupationClassRules.IsExistsAccountOccupationClass(deleteAccountOccupationClassRequest.Id);
        AccountOccupationClass accountOccupationClass = await _accountOccupationClassDal.GetAsync(predicate: a => a.Id == deleteAccountOccupationClassRequest.Id);
        AccountOccupationClass deletedAccountOccupationClass = await _accountOccupationClassDal.DeleteAsync(accountOccupationClass);
        var mappedAccountOccupationClass = _mapper.Map<DeletedAccountOccupationClassResponse>(deletedAccountOccupationClass);
        return mappedAccountOccupationClass;
    }

    public async Task<GetListAccountOccupationClassResponse> GetByAccountIdAndOccupationClassId(Guid accountId, Guid occupationClassId)
    {
        var occupationClass = await _accountOccupationClassDal.GetListAsync();

        var accountOccupationClass = await
            _accountOccupationClassDal.GetAsync(
           predicate: a => a.AccountId == accountId && a.OccupationClassId == occupationClassId,
          include: aoc => aoc.
            Include(aoc => aoc.OccupationClass)
            .Include(aoc => aoc.Account).ThenInclude(a => a.User));
        var mappedListed = _mapper.Map<GetListAccountOccupationClassResponse>(accountOccupationClass);
        return mappedListed;
    }

    public async Task<GetAccountOccupationClassResponse> GetByIdAsync(Guid id)
    {
        var accountOccupationClassList = await _accountOccupationClassDal.GetAsync(
            predicate: a => a.Id == id,
            include: aoc => aoc.
            Include(aoc => aoc.OccupationClass)
            .Include(aoc => aoc.Account).ThenInclude(a => a.User));
        var mappedAccountOccupationClass = _mapper.Map<GetAccountOccupationClassResponse>(accountOccupationClassList);
        return mappedAccountOccupationClass;
    }

    public async Task<IPaginate<GetListAccountOccupationClassResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountOccupationClassList = await _accountOccupationClassDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: aoc => aoc.
            Include(aoc => aoc.OccupationClass)
            .Include(aoc => aoc.Account).ThenInclude(a => a.User)
            );
        var mappedAccountOccupationClass = _mapper.Map<Paginate<GetListAccountOccupationClassResponse>>(accountOccupationClassList);
        return mappedAccountOccupationClass;
    }

    public async Task<UpdatedAccountOccupationClassResponse> UpdateAsync(UpdateAccountOccupationClassRequest updateAccountOccupationClassRequest)
    {
        await _accountOccupationClassRules.IsExistsAccountOccupationClass(updateAccountOccupationClassRequest.Id);
        AccountOccupationClass accountOccupationClass = _mapper.Map<AccountOccupationClass>(updateAccountOccupationClassRequest);
        AccountOccupationClass updateedAccountOccupationClass = await _accountOccupationClassDal.UpdateAsync(accountOccupationClass);
        var mappedAccountOccupationClass = _mapper.Map<UpdatedAccountOccupationClassResponse>(updateedAccountOccupationClass);
        return mappedAccountOccupationClass; 
    } 
}
