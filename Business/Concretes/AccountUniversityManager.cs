using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountUniversityRequests;
using Business.Dtos.Responses.AccountUniversityResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountUniversityManager : IAccountUniversityService
{

    IAccountUniversityDal _accountUniversityDal;
    IMapper _mapper;
    AccountUniversityBusinessRules _accountUniversityBusinessRules;

    public AccountUniversityManager(IAccountUniversityDal accountUniversityDal, IMapper mapper, AccountUniversityBusinessRules accountUniversityBusinessRules)
    {
        _accountUniversityDal = accountUniversityDal;
        _mapper = mapper;
        _accountUniversityBusinessRules = accountUniversityBusinessRules;
    }

    public async Task<CreatedAccountUniversityResponse> AddAsync(CreateAccountUniversityRequest createAccountUniversityRequest)
    {
        AccountUniversity accountUniversity = _mapper.Map<AccountUniversity>(createAccountUniversityRequest);
        AccountUniversity createdAccountUniversity = await _accountUniversityDal.AddAsync(accountUniversity);
        CreatedAccountUniversityResponse createdAccountUniversityResponse = _mapper.Map<CreatedAccountUniversityResponse>(createdAccountUniversity);
        return createdAccountUniversityResponse;
    }

    public async Task<DeletedAccountUniversityResponse> DeleteAsync(Guid id)
    {
        await _accountUniversityBusinessRules.IsExistsAccountUniversity(id);
        AccountUniversity accountUniversity = await _accountUniversityDal.GetAsync(predicate: au => au.Id == id);
        AccountUniversity deletedAccountUniversity = await _accountUniversityDal.DeleteAsync(accountUniversity);
        DeletedAccountUniversityResponse deletedAccountUniversityResponse = _mapper.Map<DeletedAccountUniversityResponse>(deletedAccountUniversity);
        return deletedAccountUniversityResponse;


    }

    public async Task<IPaginate<GetListAccountUniversityResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var accountUniversities = await _accountUniversityDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize,
             include: au => au
            .Include(au => au.University)
            .Include(au => au.DegreeType)
            .Include(au => au.UniversityDepartment)
            .Include(au => au.Account).ThenInclude(a => a.User));
        var mappedAccountUniversities = _mapper.Map<Paginate<GetListAccountUniversityResponse>>(accountUniversities);
        return mappedAccountUniversities;
    }

    public async Task<GetAccountUniversityResponse> GetByIdAsync(Guid Id)
    {
        var accountUniversity = await _accountUniversityDal.GetAsync(
            predicate: a => a.Id == Id,
            include: au => au
            .Include(au => au.University)
            .Include(au => au.DegreeType)
            .Include(au => au.UniversityDepartment)
            .Include(au => au.Account).ThenInclude(a => a.User));
        var mappedAccountUniversity = _mapper.Map<GetAccountUniversityResponse>(accountUniversity);
        return mappedAccountUniversity;
    }

    public async Task<IPaginate<GetListAccountUniversityResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountUniversities = await _accountUniversityDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: au => au
            .Include(au => au.University)
            .Include(au => au.DegreeType)
            .Include(au => au.UniversityDepartment)
            .Include(au => au.Account).ThenInclude(a => a.User));
        var mappedaccountUniversities = _mapper.Map<Paginate<GetListAccountUniversityResponse>>(accountUniversities);
        return mappedaccountUniversities;
    }


    public async Task<UpdatedAccountUniversityResponse> UpdateAsync(UpdateAccountUniversityRequest updateAccountUniversityRequest)
    {
        await _accountUniversityBusinessRules.IsExistsAccountUniversity(updateAccountUniversityRequest.Id);
        AccountUniversity accountUniversity = _mapper.Map<AccountUniversity>(updateAccountUniversityRequest);
        AccountUniversity updatedAccountUniversity = await _accountUniversityDal.UpdateAsync(accountUniversity);
        UpdatedAccountUniversityResponse updatedAccountUniversityResponse = _mapper.Map<UpdatedAccountUniversityResponse>(updatedAccountUniversity);
        return updatedAccountUniversityResponse;
    }
}
