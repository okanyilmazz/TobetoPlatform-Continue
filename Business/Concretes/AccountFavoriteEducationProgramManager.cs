using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountFavoriteEducationProgramRequests;
using Business.Dtos.Responses.AccountFavoriteEducationProgramResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountFavoriteEducationProgramManager : IAccountFavoriteEducationProgramService
{
    IAccountFavoriteEducationProgramDal _accountFavoriteEducationProgramDal;
    IMapper _mapper;
    AccountFavoriteEducationProgramBusinessRules _accountFavoriteEducationProgramBusinessRules;

    public AccountFavoriteEducationProgramManager(IAccountFavoriteEducationProgramDal accountFavoriteEducationProgramDal, IMapper mapper, AccountFavoriteEducationProgramBusinessRules accountFavoriteEducationProgramBusinessRules)
    {
        _accountFavoriteEducationProgramDal = accountFavoriteEducationProgramDal;
        _mapper = mapper;
        _accountFavoriteEducationProgramBusinessRules = accountFavoriteEducationProgramBusinessRules;
    }
    public async Task<CreatedAccountFavoriteEducationProgramResponse> AddAsync(CreateAccountFavoriteEducationProgramRequest createAccountFavoriteEducationProgramRequests)
    {
        AccountFavoriteEducationProgram accountFavoriteEducationProgram = _mapper.Map<AccountFavoriteEducationProgram>(createAccountFavoriteEducationProgramRequests);
        AccountFavoriteEducationProgram addedAccountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.AddAsync(accountFavoriteEducationProgram);
        CreatedAccountFavoriteEducationProgramResponse createdAccountFavoriteEducationProgramResponse = _mapper.Map<CreatedAccountFavoriteEducationProgramResponse>(addedAccountFavoriteEducationProgram);
        return createdAccountFavoriteEducationProgramResponse;
    }


    public async Task<DeletedAccountFavoriteEducationProgramResponse> DeleteAsync(Guid id)
    {
        await _accountFavoriteEducationProgramBusinessRules.IsExistsAccountFavoriteEducationProgram(id);
        AccountFavoriteEducationProgram accountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.GetAsync(predicate: a => a.Id == id);
        AccountFavoriteEducationProgram deletedAccountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.DeleteAsync(accountFavoriteEducationProgram);
        DeletedAccountFavoriteEducationProgramResponse deletedAccountFavoriteEducationProgramResponse = _mapper.Map<DeletedAccountFavoriteEducationProgramResponse>(deletedAccountFavoriteEducationProgram);
        return deletedAccountFavoriteEducationProgramResponse;
    }

    public async Task<DeletedAccountFavoriteEducationProgramResponse> DeleteByAccountIdAndEducationProgramIdAsync(DeleteAccountFavoriteEducationProgramRequest deleteAccountFavoriteEducationProgramRequest)
    {
        await _accountFavoriteEducationProgramBusinessRules.IsExistsAccountFavoriteEducationProgramByAccountIdAndEducationProgramId(deleteAccountFavoriteEducationProgramRequest.AccountId, deleteAccountFavoriteEducationProgramRequest.EducationProgramId);
        AccountFavoriteEducationProgram accountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.GetAsync(
        predicate: epl => epl.AccountId == deleteAccountFavoriteEducationProgramRequest.AccountId && epl.EducationProgramId == deleteAccountFavoriteEducationProgramRequest.EducationProgramId);
        AccountFavoriteEducationProgram deletedAccountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.DeleteAsync(accountFavoriteEducationProgram, permanent: true);
        DeletedAccountFavoriteEducationProgramResponse mappedDeletedAccountFavoriteEducationProgram = _mapper.Map<DeletedAccountFavoriteEducationProgramResponse>(deletedAccountFavoriteEducationProgram);
        return mappedDeletedAccountFavoriteEducationProgram;
    }

    public async Task<GetAccountFavoriteEducationProgramResponse> GetByIdAsync(Guid id)
    {
        var accountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.GetAsync(
            predicate: a => a.Id == id,
            include: afep => afep.
            Include(afep => afep.EducationProgram)
            .Include(afep => afep.Account).ThenInclude(a => a.User));
        var mappedAccountFavoriteEducationProgram = _mapper.Map<GetAccountFavoriteEducationProgramResponse>(accountFavoriteEducationProgram);
        return mappedAccountFavoriteEducationProgram;
    }

    public async Task<IPaginate<GetListAccountFavoriteEducationProgramResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var accountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.GetListAsync(
            predicate: a => a.AccountId == accountId,
            include: afep => afep.
            Include(afep => afep.EducationProgram)
            .Include(afep => afep.Account).ThenInclude(a => a.User));
        var mappedAccountFavoriteEducationProgram = _mapper.Map<Paginate<GetListAccountFavoriteEducationProgramResponse>>(accountFavoriteEducationProgram);
        return mappedAccountFavoriteEducationProgram;
    }

    public async Task<IPaginate<GetListAccountFavoriteEducationProgramResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountFavoriteEducationPrograms = await _accountFavoriteEducationProgramDal.GetListAsync(
            include: afep => afep.
            Include(afep => afep.EducationProgram)
            .Include(afep => afep.Account).ThenInclude(a => a.User));

        var mappedAccountFavoriteEducationPrograms = _mapper.Map<Paginate<GetListAccountFavoriteEducationProgramResponse>>(accountFavoriteEducationPrograms);
        return mappedAccountFavoriteEducationPrograms;
    }

    public async Task<UpdatedAccountFavoriteEducationProgramResponse> UpdateAsync(UpdateAccountFavoriteEducationProgramRequest updateAccountFavoriteEducationProgramRequest)
    {
        await _accountFavoriteEducationProgramBusinessRules.IsExistsAccountFavoriteEducationProgram(updateAccountFavoriteEducationProgramRequest.Id);
        AccountFavoriteEducationProgram accountFavoriteEducationProgram = _mapper.Map<AccountFavoriteEducationProgram>(updateAccountFavoriteEducationProgramRequest);
        AccountFavoriteEducationProgram updatedAccountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.UpdateAsync(accountFavoriteEducationProgram);
        UpdatedAccountFavoriteEducationProgramResponse updatedAccountFavoriteEducationProgramResponse = _mapper.Map<UpdatedAccountFavoriteEducationProgramResponse>(updatedAccountFavoriteEducationProgram);
        return updatedAccountFavoriteEducationProgramResponse;
    }


    public async Task<IPaginate<GetListAccountFavoriteEducationProgramResponse>> GetByEducationProgramIdAsync(Guid educationProgramId)
    {
        var accountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.GetListAsync(
          predicate: a => a.EducationProgramId == educationProgramId,
          include: afep => afep.
          Include(afep => afep.EducationProgram)
          .Include(afep => afep.Account).ThenInclude(a => a.User));
        var mappedAccountFavoriteEducationProgram = _mapper.Map<Paginate<GetListAccountFavoriteEducationProgramResponse>>(accountFavoriteEducationProgram);
        return mappedAccountFavoriteEducationProgram;
    }

    public async Task<GetAccountFavoriteEducationProgramResponse> GetByAccountIdAndEducationProgramIdAsync(Guid accountId, Guid educationProgramId)
    {
        var accountFavoriteEducationProgram = await _accountFavoriteEducationProgramDal.GetAsync(
         predicate: a => a.EducationProgramId == educationProgramId && a.AccountId == accountId,
         include: afep => afep.
         Include(afep => afep.EducationProgram)
         .Include(afep => afep.Account).ThenInclude(a => a.User));
        var mappedAccountFavoriteEducationProgram = _mapper.Map<GetAccountFavoriteEducationProgramResponse>(accountFavoriteEducationProgram);
        return mappedAccountFavoriteEducationProgram;
    }
}