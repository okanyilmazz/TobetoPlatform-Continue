using AutoMapper;
using Business.Dtos.Requests.AccountActivityMapRequests;
using Business.Dtos.Responses.AccountActivityMapResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Business.Abstracts;
namespace Business.Concretes;

public class AccountActivityMapManager : IAccountActivityMapService
{
    IAccountActivityMapDal _accountActivityMapDal;
    IMapper _mapper;
    AccountActivityMapBusinessRules _accountActivityMapBusinessRules;

    public AccountActivityMapManager(IAccountActivityMapDal accountActivityMapDal, IMapper mapper, AccountActivityMapBusinessRules accountActivityMapBusinessRules)
    {
        _accountActivityMapDal = accountActivityMapDal;
        _mapper = mapper;
        _accountActivityMapBusinessRules = accountActivityMapBusinessRules;
    }

    public async Task<CreatedAccountActivityMapResponse> AddAsync(CreateAccountActivityMapRequest createAccountActivityMapRequest)
    {
        AccountActivityMap accountActivityMap = _mapper.Map<AccountActivityMap>(createAccountActivityMapRequest);
        AccountActivityMap createdAccountActivityMap = await _accountActivityMapDal.AddAsync(accountActivityMap);
        CreatedAccountActivityMapResponse createdAccountActivityMapResponse = _mapper.Map<CreatedAccountActivityMapResponse>(createdAccountActivityMap);
        return createdAccountActivityMapResponse;
    }

    public async Task<DeletedAccountActivityMapResponse> DeleteAsync(Guid id)
    {
        await _accountActivityMapBusinessRules.IsExistsAccountActivityMap(id);
        AccountActivityMap accountActivityMap = await _accountActivityMapDal.GetAsync(predicate: ab => ab.Id == id);
        AccountActivityMap deletedAccountActivityMap = await _accountActivityMapDal.DeleteAsync(accountActivityMap);
        DeletedAccountActivityMapResponse deletedAccountActivityMapResponse = _mapper.Map<DeletedAccountActivityMapResponse>(deletedAccountActivityMap);
        return deletedAccountActivityMapResponse;
    }
    public async Task<UpdatedAccountActivityMapResponse> UpdateAsync(UpdateAccountActivityMapRequest updateAccountActivityMapRequest)
    {
        await _accountActivityMapBusinessRules.IsExistsAccountActivityMap(updateAccountActivityMapRequest.Id);
        AccountActivityMap accountActivityMap = _mapper.Map<AccountActivityMap>(updateAccountActivityMapRequest);
        AccountActivityMap updateAccountActivityMap = await _accountActivityMapDal.UpdateAsync(accountActivityMap);
        UpdatedAccountActivityMapResponse updatedAccountActivityMapResponse = _mapper.Map<UpdatedAccountActivityMapResponse>(updateAccountActivityMap);
        return updatedAccountActivityMapResponse;
    }

    public async Task<IPaginate<GetListAccountActivityMapResponse>> GetByAccountIdAsync(Guid Id)
    {
        var accountActivityMapList = await _accountActivityMapDal.GetListAsync(
            predicate: ab => ab.AccountId == Id,
            include: ab => ab   
            .Include(ab => ab.Account).ThenInclude(ab => ab.User)
            .Include(ab => ab.ActivityMap));

        var groupedItems = accountActivityMapList.Items
     .GroupBy(c => c.ActivityMap.Date)
     .Select(group => new GetListAccountActivityMapResponse {DateTime=group.Key.ToString(),Count=group.Count()})
     .ToList();


        var mappedAccountActivityMaps = _mapper.Map<Paginate<GetListAccountActivityMapResponse>>(groupedItems);
        return mappedAccountActivityMaps;
    }


    public async Task<GetAccountActivityMapResponse> GetByIdAsync(Guid Id)
    {
        var accountActivityMap = await _accountActivityMapDal.GetAsync(
            predicate: b => b.Id == Id,
            include: ab => ab
            .Include(ab => ab.Account).ThenInclude(ab => ab.User)
            .Include(ab => ab.ActivityMap));
        var mappedAccountActivityMap = _mapper.Map<GetAccountActivityMapResponse>(accountActivityMap);
        return mappedAccountActivityMap;
    }

    public async Task<IPaginate<GetListAccountActivityMapResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountActivityMaps = await _accountActivityMapDal.GetListAsync(
               index: pageRequest.PageIndex,
               size: pageRequest.PageSize,
               include: ab => ab
               .Include(ab => ab.Account).ThenInclude(ab => ab.User)
               .Include(ab => ab.ActivityMap)
               );
        var mappedAccountActivityMaps = _mapper.Map<Paginate<GetListAccountActivityMapResponse>>(accountActivityMaps);
        return mappedAccountActivityMaps;
    }
}

