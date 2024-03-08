using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountSessionRequests;
using Business.Dtos.Responses.AccountSessionResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountSessionManager : IAccountSessionService
{
    IAccountSessionDal _accountSessionDal;
    IMapper _mapper;
    AccountSessionBusinessRules _accountSessionBusinessRules;

    public AccountSessionManager(IAccountSessionDal accountSessionDal, IMapper mapper, AccountSessionBusinessRules accountSessionBusinessRules)
    {
        _accountSessionDal = accountSessionDal;
        _mapper = mapper;
        _accountSessionBusinessRules = accountSessionBusinessRules;
    }

    public async Task<CreatedAccountSessionResponse> AddAsync(CreateAccountSessionRequest createAccountSessionRequest)
    {
        await _accountSessionBusinessRules.IsExistsAccountSessionByAccountAndSessionId(createAccountSessionRequest.AccountId, createAccountSessionRequest.SessionId);
        AccountSession accountSession = _mapper.Map<AccountSession>(createAccountSessionRequest);
        AccountSession addedAccountSession = await _accountSessionDal.AddAsync(accountSession);
        CreatedAccountSessionResponse createdAccountSessionResponse = _mapper.Map<CreatedAccountSessionResponse>(addedAccountSession);
        return createdAccountSessionResponse;

    }

    public async Task<DeletedAccountSessionResponse> DeleteAsync(DeleteAccountSessionRequest deleteAccountSessionRequest)
    {
        await _accountSessionBusinessRules.IsExistsAccountSession(deleteAccountSessionRequest.Id);
        AccountSession accountSession = await _accountSessionDal.GetAsync(predicate: a => a.Id == deleteAccountSessionRequest.Id);
        AccountSession deletedAccountSession = await _accountSessionDal.DeleteAsync(accountSession);
        DeletedAccountSessionResponse createdAccountSessionResponse = _mapper.Map<DeletedAccountSessionResponse>(deletedAccountSession);
        return createdAccountSessionResponse;

    }

    public async Task<GetListAccountSessionResponse> GetByIdAsync(Guid id)
    {
        var accountSession = await _accountSessionDal.GetAsync(a => a.Id == id);
        var mappedAccountSession = _mapper.Map<GetListAccountSessionResponse>(accountSession);
        return mappedAccountSession;
    }


    public async Task<IPaginate<GetListAccountSessionResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var accountSessions = await _accountSessionDal.GetListAsync(
            predicate:a => a.AccountId == accountId);
        var mappedAccountSessions = _mapper.Map<Paginate<GetListAccountSessionResponse>>(accountSessions);
        return mappedAccountSessions;
    }


    public async Task<GetListAccountSessionResponse> GetByAccountAndSessionIdAsync(Guid accountId, Guid sessionId)
    {
        var accountSession = await _accountSessionDal.GetAsync(
            predicate: a => a.AccountId == accountId && a.SessionId == sessionId);
        var mappedAccountSession = _mapper.Map<GetListAccountSessionResponse>(accountSession);
        return mappedAccountSession;
    }



    public async Task<IPaginate<GetListAccountSessionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountSession = await _accountSessionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: ase => ase
            .Include(ase => ase.Account).ThenInclude(a => a.User));
        var mappedAccountSession = _mapper.Map<Paginate<GetListAccountSessionResponse>>(accountSession);
        return mappedAccountSession;
    }

    public async Task<UpdatedAccountSessionResponse> UpdateAsync(UpdateAccountSessionRequest updateAccountSessionRequest)
    {
        await _accountSessionBusinessRules.IsExistsAccountSession(updateAccountSessionRequest.SessionId);
        AccountSession accountSession = _mapper.Map<AccountSession>(updateAccountSessionRequest);
        AccountSession updatedAccountSession = await _accountSessionDal.UpdateAsync(accountSession);
        UpdatedAccountSessionResponse updatedAccountSessionResponse = _mapper.Map<UpdatedAccountSessionResponse>(updatedAccountSession);
        return updatedAccountSessionResponse;
    }
}
