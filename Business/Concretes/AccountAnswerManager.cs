using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountAnswerRequests;
using Business.Dtos.Responses.AccountAnswerResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountAnswerManager : IAccountAnswerService
{
    IAccountAnswerDal _accountAnswerDal;
    IMapper _mapper;
    AccountAnswerBusinessRules _accountAnswerBusinessRules;

    public AccountAnswerManager(IAccountAnswerDal accountAnswerDal, IMapper mapper, AccountAnswerBusinessRules accountAnswerBusinessRules)
    {
        _accountAnswerDal = accountAnswerDal;
        _mapper = mapper;
        _accountAnswerBusinessRules = accountAnswerBusinessRules;
    }
    public async Task<CreatedAccountAnswerResponse> AddAsync(CreateAccountAnswerRequest createAccountAnswerRequest)
    {
        AccountAnswer accountAnswer = _mapper.Map<AccountAnswer>(createAccountAnswerRequest);
        AccountAnswer addedAccountAnswer = await _accountAnswerDal.AddAsync(accountAnswer);
        CreatedAccountAnswerResponse createdAccountAnswerResponse = _mapper.Map<CreatedAccountAnswerResponse>(addedAccountAnswer);
        return createdAccountAnswerResponse;
    }

    public async Task<DeletedAccountAnswerResponse> DeleteAsync(Guid id)
    {
        await _accountAnswerBusinessRules.IsExistsAccountAnswer(id);
        AccountAnswer accountAnswer = await _accountAnswerDal.GetAsync(predicate: l => l.Id == id);
        AccountAnswer deletedAccountAnswer = await _accountAnswerDal.DeleteAsync(accountAnswer);
        DeletedAccountAnswerResponse deletedAccountAnswerResponse = _mapper.Map<DeletedAccountAnswerResponse>(deletedAccountAnswer);
        return deletedAccountAnswerResponse;
    }

    public async Task<GetAccountAnswerResponse> GetByIdAsync(Guid id)
    {
        var accountAnswers = await _accountAnswerDal.GetAsync(
            predicate: a => a.Id == id,
            include: aa => aa
            .Include(a => a.Exam)
            .Include(a => a.Account).ThenInclude(a => a.User)
            .Include(a => a.Question));
        var mappedAccountAnswers = _mapper.Map<GetAccountAnswerResponse>(accountAnswers);
        return mappedAccountAnswers;
    }

    public async Task<IPaginate<GetListAccountAnswerResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountAnswers = await _accountAnswerDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: aa => aa
            .Include(a => a.Exam)
            .Include(a => a.Account).ThenInclude(a => a.User)
            .Include(a => a.Question));
        var mappedAccountAnswers = _mapper.Map<Paginate<GetListAccountAnswerResponse>>(accountAnswers);
        return mappedAccountAnswers;
    }

    public async Task<UpdatedAccountAnswerResponse> UpdateAsync(UpdateAccountAnswerRequest updateAccountAnswerRequest)
    {
        await _accountAnswerBusinessRules.IsExistsAccountAnswer(updateAccountAnswerRequest.Id);
        AccountAnswer accountAnswer = _mapper.Map<AccountAnswer>(updateAccountAnswerRequest);
        AccountAnswer updatedAccountAnswer = await _accountAnswerDal.UpdateAsync(accountAnswer);
        UpdatedAccountAnswerResponse updatedAccountAnswerResponse = _mapper.Map<UpdatedAccountAnswerResponse>(updatedAccountAnswer);
        return updatedAccountAnswerResponse;
    }
}
