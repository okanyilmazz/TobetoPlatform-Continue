using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountEducationProgramRequests;
using Business.Dtos.Responses.AccountEducationProgramResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountEducationProgramManager : IAccountEducationProgramService
{
    IAccountEducationProgramDal _accountEducationProgramDal;
    IMapper _mapper;
    AccountEducationProgramBusinessRules _accountEducationProgramBusinessRules;

    public AccountEducationProgramManager(IAccountEducationProgramDal accountEducationProgramDal, IMapper mapper, AccountEducationProgramBusinessRules accountEducationProgramBusinessRules)
    {
        _accountEducationProgramDal = accountEducationProgramDal;
        _mapper = mapper;
        _accountEducationProgramBusinessRules = accountEducationProgramBusinessRules;
    }

    public async Task<CreatedAccountEducationProgramResponse> AddAsync(CreateAccountEducationProgramRequest createAccountEducationProgramRequest)
    {
        AccountEducationProgram accountEducationProgram = _mapper.Map<AccountEducationProgram>(createAccountEducationProgramRequest);
        AccountEducationProgram createdAccountEducationProgram = await _accountEducationProgramDal.AddAsync(accountEducationProgram);
        CreatedAccountEducationProgramResponse createdAccountEducationProgramResponse = _mapper.Map<CreatedAccountEducationProgramResponse>(createdAccountEducationProgram);
        return createdAccountEducationProgramResponse;
    }

    public async Task<DeletedAccountEducationProgramResponse> DeleteAsync(DeleteAccountEducationProgramRequest deleteAccountEducationProgramRequest)
    {
        await _accountEducationProgramBusinessRules.IsExistsAccountEducationProgram(deleteAccountEducationProgramRequest.Id);
        AccountEducationProgram accountEducationProgram = await _accountEducationProgramDal.GetAsync(predicate: a => a.Id == deleteAccountEducationProgramRequest.Id);
        AccountEducationProgram deletedAccountEducationProgram = await _accountEducationProgramDal.DeleteAsync(accountEducationProgram);
        DeletedAccountEducationProgramResponse deletedAccountEducationProgrameResponse = _mapper.Map<DeletedAccountEducationProgramResponse>(deletedAccountEducationProgram);
        return deletedAccountEducationProgrameResponse;
    }

    public async Task<IPaginate<GetListAccountEducationProgramResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var accountEducationProgram = await _accountEducationProgramDal.GetListAsync(
           predicate: a => a.AccountId == accountId,
           include: ah => ah
           .Include(ah => ah.Account).ThenInclude(a => a.User)
           .Include(ah => ah.EducationProgram));
        var mappedAccountEducationProgram = _mapper.Map<Paginate<GetListAccountEducationProgramResponse>>(accountEducationProgram);
        return mappedAccountEducationProgram;
    }

    public async Task<GetAccountEducationProgramResponse> GetByAccountIdAndEducationProgramIdAsync(Guid accountId, Guid educationProgramId)
    {
        var accountEducationProgram = await _accountEducationProgramDal.GetAsync(
           predicate: a => a.AccountId == accountId && a.EducationProgramId == educationProgramId,
           include: ah => ah
           .Include(ah => ah.Account).ThenInclude(a => a.User)
           .Include(ah => ah.EducationProgram));
        var mappedAccountEducationProgram = _mapper.Map<GetAccountEducationProgramResponse>(accountEducationProgram);
        return mappedAccountEducationProgram;
    }

    public async Task<GetAccountEducationProgramResponse> GetByIdAsync(Guid id)
    {
        var accountEducationProgram = await _accountEducationProgramDal.GetAsync(
            predicate: a => a.Id == id,
            include: ah => ah
            .Include(ah => ah.Account).ThenInclude(a => a.User)
            .Include(ah => ah.EducationProgram));
        var mappedAccountEducationProgram = _mapper.Map<GetAccountEducationProgramResponse>(accountEducationProgram);
        return mappedAccountEducationProgram;
    }

    public async Task<IPaginate<GetListAccountEducationProgramResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountEducationProgram = await _accountEducationProgramDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: ah => ah
            .Include(ah => ah.Account).ThenInclude(a => a.User)
            .Include(ah => ah.EducationProgram));
        var mappedAccountEducationProgram = _mapper.Map<Paginate<GetListAccountEducationProgramResponse>>(accountEducationProgram);
        return mappedAccountEducationProgram;
    }

    public async Task<UpdatedAccountEducationProgramResponse> UpdateAsync(UpdateAccountEducationProgramRequest updateAccountEducationProgramRequest)
    {
        await _accountEducationProgramBusinessRules.IsExistsAccountEducationProgram(updateAccountEducationProgramRequest.Id);
        AccountEducationProgram accountEducationProgram = _mapper.Map<AccountEducationProgram>(updateAccountEducationProgramRequest);
        AccountEducationProgram updatedAccountEducationProgram = await _accountEducationProgramDal.UpdateAsync(accountEducationProgram);
        UpdatedAccountEducationProgramResponse updatedAccountEducationProgrameResponse = _mapper.Map<UpdatedAccountEducationProgramResponse>(updatedAccountEducationProgram);
        return updatedAccountEducationProgrameResponse;
    }
}
