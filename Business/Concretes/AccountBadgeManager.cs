using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountBadgeRequests;
using Business.Dtos.Responses.AccountBadgeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountBadgeManager : IAccountBadgeService
{
    IAccountBadgeDal _accountBadgeDal;
    IMapper _mapper;
    AccountBadgeBusinessRules _accountBadgeBusinessRules;

    public AccountBadgeManager(IAccountBadgeDal accountBadgeDal, IMapper mapper, AccountBadgeBusinessRules accountBadgeBusinessRules)
    {
        _accountBadgeDal = accountBadgeDal;
        _mapper = mapper;
        _accountBadgeBusinessRules = accountBadgeBusinessRules;
    }

    public async Task<CreatedAccountBadgeResponse> AddAsync(CreateAccountBadgeRequest createAccountBadgeRequest)
    {
        AccountBadge accountBadge = _mapper.Map<AccountBadge>(createAccountBadgeRequest);
        AccountBadge createdAccountBadge = await _accountBadgeDal.AddAsync(accountBadge);
        CreatedAccountBadgeResponse createdAccountBadgeResponse = _mapper.Map<CreatedAccountBadgeResponse>(createdAccountBadge);
        return createdAccountBadgeResponse;
    }

    public async Task<DeletedAccountBadgeResponse> DeleteAsync(Guid id)
    {
        await _accountBadgeBusinessRules.IsExistsAccountBadge(id);
        AccountBadge accountBadge = await _accountBadgeDal.GetAsync(predicate: ab => ab.Id == id);
        AccountBadge deletedAccountBadge = await _accountBadgeDal.DeleteAsync(accountBadge);
        DeletedAccountBadgeResponse deletedAccountBadgeResponse = _mapper.Map<DeletedAccountBadgeResponse>(deletedAccountBadge);
        return deletedAccountBadgeResponse;
    }
    public async Task<UpdatedAccountBadgeResponse> UpdateAsync(UpdateAccountBadgeRequest updateAccountBadgeRequest)
    {
        await _accountBadgeBusinessRules.IsExistsAccountBadge(updateAccountBadgeRequest.Id);
        AccountBadge accountBadge = _mapper.Map<AccountBadge>(updateAccountBadgeRequest);
        AccountBadge updateAccountBadge = await _accountBadgeDal.UpdateAsync(accountBadge);
        UpdatedAccountBadgeResponse updatedAccountBadgeResponse = _mapper.Map<UpdatedAccountBadgeResponse>(updateAccountBadge);
        return updatedAccountBadgeResponse;
    }

    public async Task<IPaginate<GetListAccountBadgeResponse>> GetByAccountIdAsync(Guid Id)
    {
        var accountBadgeList = await _accountBadgeDal.GetListAsync(
             include: ab => ab
               .Include(ab => ab.Account)
               .ThenInclude(a => a.User) 
               .Include(ab => ab.Badge)
               );
        var filteredAccountBadges = accountBadgeList
            .Items.Where(ab => ab.AccountId == Id).ToList();

        var mappedAccountBadges = _mapper.Map<Paginate<GetListAccountBadgeResponse>>(filteredAccountBadges);
        return mappedAccountBadges;
    }

    public async Task<GetAccountBadgeResponse> GetByAccountAndBadgeIdAsync(Guid accountId, Guid badgeId)
    {
        var accountBadge = await _accountBadgeDal.GetAsync(
            predicate:b=>b.AccountId==accountId && b.BadgeId==badgeId,
              include: ab => ab
               .Include(ab => ab.Account).ThenInclude(a => a.User)
               .Include(ab => ab.Badge));
            
        var mappedAccountBadge = _mapper.Map<GetAccountBadgeResponse>(accountBadge);
        return mappedAccountBadge;
    }

    public async Task<GetAccountBadgeResponse> GetByIdAsync(Guid Id)
    {
        var accountBadge = await _accountBadgeDal.GetAsync(
            predicate: b => b.Id == Id,
            include: ab => ab
               .Include(ab => ab.Account).ThenInclude(a => a.User)
               .Include(ab => ab.Badge));
        var mappedAccountBadge = _mapper.Map<GetAccountBadgeResponse>(accountBadge);
        return mappedAccountBadge;
    }

    public async Task<IPaginate<GetListAccountBadgeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountBadges = await _accountBadgeDal.GetListAsync(
               index: pageRequest.PageIndex,    
               size: pageRequest.PageSize,
               include: ab => ab
               .Include(ab => ab.Account).ThenInclude(a => a.User)
               .Include(ab => ab.Badge)
               );
        var mappedAccountBadges = _mapper.Map<Paginate<GetListAccountBadgeResponse>>(accountBadges);
        return mappedAccountBadges;
    }
}