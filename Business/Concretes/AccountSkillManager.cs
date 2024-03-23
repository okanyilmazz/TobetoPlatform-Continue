using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountSkillRequests;
using Business.Dtos.Responses.AccountSkillResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountSkillManager : IAccountSkillService
{
    IAccountSkillDal _accountSkillDal;
    IMapper _mapper;
    AccountSkillBusinessRules _accountSkillBusinessRules;

    public AccountSkillManager(IAccountSkillDal accountSkillDal, IMapper mapper, AccountSkillBusinessRules accountSkillBusinessRules)
    {
        _accountSkillDal = accountSkillDal;
        _mapper = mapper;
        _accountSkillBusinessRules = accountSkillBusinessRules;
    }
    public async Task<CreatedAccountSkillResponse> AddAsync(CreateAccountSkillRequest createAccountSkillRequests)
    {
        AccountSkill accountSkill = _mapper.Map<AccountSkill>(createAccountSkillRequests);
        AccountSkill addedAccountSkill = await _accountSkillDal.AddAsync(accountSkill);
        CreatedAccountSkillResponse createdAccountSkillResponse = _mapper.Map<CreatedAccountSkillResponse>(addedAccountSkill);
        return createdAccountSkillResponse;
    }

    public async Task<ICollection<CreatedAccountSkillResponse>> AddRangeAsync(ICollection<CreateAccountSkillRequest> createAccountSkillRequests)
    {
        ICollection<AccountSkill> accountSkills = _mapper.Map<ICollection<AccountSkill>>(createAccountSkillRequests);
        ICollection<AccountSkill> addedAccountSkills = await _accountSkillDal.AddRangeAsync(accountSkills);
        ICollection<CreatedAccountSkillResponse> createdAccountSkillResponses = _mapper.Map<ICollection<CreatedAccountSkillResponse>>(addedAccountSkills);
        return createdAccountSkillResponses;
    }

    public async Task<DeletedAccountSkillResponse> DeleteAsync(Guid id)
    {
        await _accountSkillBusinessRules.IsExistsAccountSkill(id);
        AccountSkill accountSkill = await _accountSkillDal.GetAsync(predicate: a => a.Id == id);
        AccountSkill deletedAccountSkill = await _accountSkillDal.DeleteAsync(accountSkill);
        DeletedAccountSkillResponse deletedAccountSkillResponse = _mapper.Map<DeletedAccountSkillResponse>(deletedAccountSkill);
        return deletedAccountSkillResponse;
    }

    public async Task<GetAccountSkillResponse> GetByIdAsync(Guid id)
    {
        var accountSkill = await _accountSkillDal.GetAsync(
            predicate: a => a.Id == id,
            include: acs => acs.
            Include(acs => acs.Skill)
            .Include(acs => acs.Account).ThenInclude(a => a.User));
        var mappedAccountSkill = _mapper.Map<GetAccountSkillResponse>(accountSkill);
        return mappedAccountSkill;
    }

    public async Task<IPaginate<GetListAccountSkillResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var accountSkill = await _accountSkillDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            predicate: a => a.AccountId == accountId,
            include: acs => acs.
            Include(acs => acs.Skill)
            .Include(acs => acs.Account).ThenInclude(a => a.User));
        var mappedAccountSkill = _mapper.Map<Paginate<GetListAccountSkillResponse>>(accountSkill);
        return mappedAccountSkill;
    }

    public async Task<IPaginate<GetListAccountSkillResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountSkills = await _accountSkillDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: acs => acs.
            Include(acs => acs.Skill)
            .Include(acs => acs.Account).ThenInclude(a => a.User));

        var mappedAccountSkills = _mapper.Map<Paginate<GetListAccountSkillResponse>>(accountSkills);
        return mappedAccountSkills;
    }

    public async Task<UpdatedAccountSkillResponse> UpdateAsync(UpdateAccountSkillRequest updateAccountSkillRequest)
    {
        await _accountSkillBusinessRules.IsExistsAccountSkill(updateAccountSkillRequest.Id);
        AccountSkill accountSkill = _mapper.Map<AccountSkill>(updateAccountSkillRequest);
        AccountSkill updatedAccountSkill = await _accountSkillDal.UpdateAsync(accountSkill);
        UpdatedAccountSkillResponse updatedAccountSkillResponse = _mapper.Map<UpdatedAccountSkillResponse>(updatedAccountSkill);
        return updatedAccountSkillResponse;
    }
}