using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountHomeworkRequests;
using Business.Dtos.Responses.AccountHomeworkResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountHomeworkManager : IAccountHomeworkService
{
    IAccountHomeworkDal _accountHomeworkDal;
    IMapper _mapper;
    AccountHomeworkBusinessRules _accountHomeworkBusinessRules;
    public AccountHomeworkManager(IAccountHomeworkDal accountHomeworkDal, IMapper mapper, AccountHomeworkBusinessRules accountHomeworkBusinessRules)
    {
        _accountHomeworkDal = accountHomeworkDal;
        _mapper = mapper;
        _accountHomeworkBusinessRules = accountHomeworkBusinessRules;
    }


    public async Task<CreatedAccountHomeworkResponse> AddAsync(CreateAccountHomeworkRequest createAccountHomeworkRequest)
    {
        AccountHomework accountHomework = _mapper.Map<AccountHomework>(createAccountHomeworkRequest);
        AccountHomework createdAccountHomework = await _accountHomeworkDal.AddAsync(accountHomework);
        CreatedAccountHomeworkResponse createdAccountHomeworkResponse = _mapper.Map<CreatedAccountHomeworkResponse>(createdAccountHomework);
        return createdAccountHomeworkResponse;
    }

    public async Task<DeletedAccountHomeworkResponse> DeleteAsync(Guid id)
    {
        await _accountHomeworkBusinessRules.IsExistsAccountHomework(id);
        AccountHomework accountHomework = await _accountHomeworkDal.GetAsync(predicate: a => a.Id == id);
        AccountHomework deletedAccountHomework = await _accountHomeworkDal.DeleteAsync(accountHomework);
        DeletedAccountHomeworkResponse deletedAccountHomeworkeResponse = _mapper.Map<DeletedAccountHomeworkResponse>(deletedAccountHomework);
        return deletedAccountHomeworkeResponse;
    }

    public async Task<GetAccountHomeworkResponse> GetByIdAsync(Guid id)
    {
        var accountHomework = await _accountHomeworkDal.GetAsync(
            predicate: a => a.Id == id,
            include: ah => ah
            .Include(ah => ah.Account).ThenInclude(a => a.User)
            .Include(ah => ah.Homework));
        var mappedAccountHomework = _mapper.Map<GetAccountHomeworkResponse>(accountHomework);
        return mappedAccountHomework;
    }

    public async Task<IPaginate<GetListAccountHomeworkResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountHomework = await _accountHomeworkDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: ah => ah
            .Include(ah => ah.Account).ThenInclude(a => a.User)
            .Include(ah => ah.Homework));
        var mappedAccountHomework = _mapper.Map<Paginate<GetListAccountHomeworkResponse>>(accountHomework);
        return mappedAccountHomework;
    }

    public async Task<UpdatedAccountHomeworkResponse> UpdateAsync(UpdateAccountHomeworkRequest updateAccountHomeworkRequest)
    {
        await _accountHomeworkBusinessRules.IsExistsAccountHomework(updateAccountHomeworkRequest.Id);
        AccountHomework accountHomework = _mapper.Map<AccountHomework>(updateAccountHomeworkRequest);
        AccountHomework updatedAccountHomework = await _accountHomeworkDal.UpdateAsync(accountHomework);
        UpdatedAccountHomeworkResponse updatedAccountHomeworkeResponse = _mapper.Map<UpdatedAccountHomeworkResponse>(updatedAccountHomework);
        return updatedAccountHomeworkeResponse;
    }
}