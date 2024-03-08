using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountSocialMediaRequests;
using Business.Dtos.Responses.AccountSkillResponses;
using Business.Dtos.Responses.AccountSocialMediaResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AccountSocialMediaManager : IAccountSocialMediaService
{
    IAccountSocialMediaDal _accountSocialMediaDal;
    IMapper _mapper;
    AccountSocialMediaBusinessRules _accountSocialMediaBusinessRules;

    public AccountSocialMediaManager(IAccountSocialMediaDal accountSocialMediaDal, IMapper mapper, AccountSocialMediaBusinessRules accountSocialMediaBusinessRules)
    {
        _accountSocialMediaDal = accountSocialMediaDal;
        _mapper = mapper;
        _accountSocialMediaBusinessRules = accountSocialMediaBusinessRules;
    }
    public async Task<CreatedAccountSocialMediaResponse> AddAsync(CreateAccountSocialMediaRequest createAccountSocialMediaRequest)
    {
        AccountSocialMedia accountSocialMedia = _mapper.Map<AccountSocialMedia>(createAccountSocialMediaRequest);
        AccountSocialMedia addedAccountSocialMedia = await _accountSocialMediaDal.AddAsync(accountSocialMedia);
        CreatedAccountSocialMediaResponse createdAccountSocialMediaResponse = _mapper.Map<CreatedAccountSocialMediaResponse>(addedAccountSocialMedia);
        return createdAccountSocialMediaResponse;
    }

    public async Task<DeletedAccountSocialMediaResponse> DeleteAsync(DeleteAccountSocialMediaRequest deleteAccountSocialMediaRequest)
    {
        AccountSocialMedia accountSocialMedia = await _accountSocialMediaDal.GetAsync(predicate: a => a.Id == deleteAccountSocialMediaRequest.Id);
        AccountSocialMedia deletedAccountSocialMedia = await _accountSocialMediaDal.DeleteAsync(accountSocialMedia);
        DeletedAccountSocialMediaResponse deletedAccountSocialMediaResponse = _mapper.Map<DeletedAccountSocialMediaResponse>(deletedAccountSocialMedia);
        return deletedAccountSocialMediaResponse;
    }

    public async Task<GetAccountSocialMediaResponse> GetByIdAsync(Guid Id)
    {
        var accountSocialMedia = await _accountSocialMediaDal.GetAsync(
            predicate: a => a.Id == Id,
            include: asm => asm
            .Include(asm => asm.SocialMedia)
            .Include(asm => asm.Account).ThenInclude(a => a.User));

        var mappedAccountSocialMedia = _mapper.Map<GetAccountSocialMediaResponse>(accountSocialMedia);
        return mappedAccountSocialMedia;
    }

    public async Task<IPaginate<GetListAccountSocialMediaResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var accountSocialMedia = await _accountSocialMediaDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            predicate: a => a.AccountId == accountId,
            include: acs => acs
            .Include(acs => acs.SocialMedia)
            .Include(acs => acs.Account).ThenInclude(a => a.User));
        var mappedAccountSocialMedia = _mapper.Map<Paginate<GetListAccountSocialMediaResponse>>(accountSocialMedia);
        return mappedAccountSocialMedia;
    }

    public async Task<IPaginate<GetListAccountSocialMediaResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountSocialMediaList = await _accountSocialMediaDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: asm => asm
            .Include(asm => asm.SocialMedia)
            .Include(asm => asm.Account).ThenInclude(a => a.User)
            );
        var mappedAccountSocialMedias = _mapper.Map<Paginate<GetListAccountSocialMediaResponse>>(accountSocialMediaList);
        return mappedAccountSocialMedias;
    }

    public async Task<UpdatedAccountSocialMediaResponse> UpdateAsync(UpdateAccountSocialMediaRequest updateAccountSocialMediaRequest)
    {
        await _accountSocialMediaBusinessRules.IsExistsAccountSocialMedia(updateAccountSocialMediaRequest.Id);
        AccountSocialMedia accountSocialMedia = _mapper.Map<AccountSocialMedia>(updateAccountSocialMediaRequest);
        AccountSocialMedia updatedAccountSocialMedia = await _accountSocialMediaDal.UpdateAsync(accountSocialMedia);
        UpdatedAccountSocialMediaResponse updatedAccountSocialMediaResponse = _mapper.Map<UpdatedAccountSocialMediaResponse>(updatedAccountSocialMedia);
        return updatedAccountSocialMediaResponse;
    }
}
