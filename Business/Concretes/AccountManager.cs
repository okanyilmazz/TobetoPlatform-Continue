using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountRequests;
using Business.Dtos.Responses.AccountResponses;
using Business.Dtos.Responses.CertificateResponses;
using Business.Messages;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using Core.Utilities.Helpers;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Business.Concretes;

public class AccountManager : IAccountService
{

    IAccountDal _accountDal;
    IMapper _mapper;
    AccountBusinessRules _accountBusinessRules;
    IFileHelper _fileHelper;

    public AccountManager(IAccountDal accountDal, IMapper mapper, AccountBusinessRules accountBusinessRules, IFileHelper fileHelper)
    {
        _accountDal = accountDal;
        _mapper = mapper;
        _accountBusinessRules = accountBusinessRules;
        _fileHelper = fileHelper;
    }

    public async Task<CreatedAccountResponse> AddAsync(CreateAccountRequest createAccountRequest)
    {
        await _accountBusinessRules.IsExistsNationalId(createAccountRequest.NationalId);
        await _accountBusinessRules.IsExistsPhoneNumber(createAccountRequest.PhoneNumber);

        Account account = _mapper.Map<Account>(createAccountRequest);
        Account addedAccount = await _accountDal.AddAsync(account);
        CreatedAccountResponse createdAccountResponse = _mapper.Map<CreatedAccountResponse>(addedAccount);
        return createdAccountResponse;
    }

   

    public async Task<DeletedAccountResponse> DeleteAsync(Guid id)
    {
        await _accountBusinessRules.IsExistsAccount(id);
        Account account = await _accountDal.GetAsync(predicate: l => l.Id == id);
        Account deletedAccount = await _accountDal.DeleteAsync(account);
        DeletedAccountResponse deletedAccountResponse = _mapper.Map<DeletedAccountResponse>(deletedAccount);
        return deletedAccountResponse;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetStudentBySessionIdAsync(Guid sessionId)
    {
        var accountList = await _accountDal.GetListAsync(
            include: a => a
            .Include(s => s.AccountSessions)
            .ThenInclude(s => s.Session)
            .Include(s => s.User),

            predicate: a => a.AccountSessions
            .Any(s => s.SessionId == sessionId && s.Account.User.UserOperationClaims
            .Any(uoc => uoc.OperationClaim.Name == Roles.Student)));
        var mappedAccounts = _mapper.Map<Paginate<GetListAccountResponse>>(accountList);
        return mappedAccounts;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetInstructorBySessionIdAsync(Guid sessionId)
    {
        var accountList = await _accountDal.GetListAsync(
            include: a => a
            .Include(s => s.AccountSessions)
            .ThenInclude(s => s.Session)
            .Include(s => s.User),

            predicate: a => a.AccountSessions
            .Any(s => s.SessionId == sessionId && s.Account.User.UserOperationClaims
            .Any(uoc => uoc.OperationClaim.Name == Roles.Instructor)));
        var mappedAccounts = _mapper.Map<Paginate<GetListAccountResponse>>(accountList);
        return mappedAccounts;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetListAsync(PageRequest pageRequest)
    {
        var account = await _accountDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: a => a
            .Include(a => a.User)
            .Include(a => a.AccountOccupationClasses).ThenInclude(aoc => aoc.OccupationClass));
        var mappedAccountSession = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccountSession;
    }

    public async Task<GetAccountResponse> GetByIdAsync(Guid id)
    {
        var account = await _accountDal.GetAsync(
            predicate: a => a.Id == id,
            include: a => a
            .Include(a => a.User)
            .Include(a => a.AccountOccupationClasses).ThenInclude(aoc => aoc.OccupationClass));
        var mappedAccount = _mapper.Map<GetAccountResponse>(account);
        return mappedAccount;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetByLessonIdForLikeAsync(Guid lessonId, PageRequest pageRequest)
    {
        var account = await _accountDal.GetListAsync(
            predicate: a => a.LessonLikes.Any(ll => ll.LessonId == lessonId),
            size: pageRequest.PageSize,
            index: pageRequest.PageIndex,
            include: a => a
            .Include(a => a.LessonLikes)
            .Include(a => a.User));
        var mappedAccount = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccount;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetByEducationProgramIdForLikeAsync(Guid educationProgramId, PageRequest pageRequest)
    {
        var account = await _accountDal.GetListAsync(
            predicate: a => a.EducationProgramLikes.Any(epl => epl.EducationProgramId == educationProgramId),
            size: pageRequest.PageSize,
            index: pageRequest.PageIndex,
            include: a => a
            .Include(a => a.EducationProgramLikes)
            .Include(a => a.User));
        var mappedAccount = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccount;
    }

    public async Task<UpdatedAccountResponse> UpdateAsync(UpdateAccountRequest updateAccountRequest)
    {
        await _accountBusinessRules.IsExistsAccount(updateAccountRequest.Id);

        Account account = _mapper.Map<Account>(updateAccountRequest);
        Account updatedAccount = await _accountDal.UpdateAsync(account);
        UpdatedAccountResponse updatedAccountResponse = _mapper.Map<UpdatedAccountResponse>(updatedAccount);
        return updatedAccountResponse;
    }

    public async Task<IPaginate<GetListAccountResponse>> GetByEducationProgramIAsync(Guid educationProgramId)
    {
        var account = await _accountDal.GetListAsync(
            predicate: a => a.AccountEducationPrograms.Any(epl => epl.EducationProgramId == educationProgramId),
             include: a => a
            .Include(a => a.AccountEducationPrograms)
            .ThenInclude(a => a.EducationProgram));
        var mappedAccount = _mapper.Map<Paginate<GetListAccountResponse>>(account);
        return mappedAccount;
    }

    public async Task UpdateImageAsync(UpdateAccountImageRequest updateAccountImageRequest)
    {
        await _accountBusinessRules.IsExistsAccount(updateAccountImageRequest.Id);

        /* Server */

        #region
        //Account account = await _accountDal.GetAsync(predicate: a => a.Id == updateAccountImageRequest.Id);
        //await _fileHelper.Update(updateAccountImageRequest.File, account.ProfilePhotoPath);
        #endregion

        /* Localhost */

        #region
        Account account = await _accountDal.GetAsync(predicate: a => a.Id == updateAccountImageRequest.Id);
        string accountProfilePath = account.ProfilePhotoPath.Substring(PathConstant.LocalBaseUrlImagePath.Length);
        string newFolderPathForLocal = PathConstant.LocalImagePath + accountProfilePath;
        await _fileHelper.Update(updateAccountImageRequest.File, newFolderPathForLocal);
        #endregion
    }

    public async Task<CreatedAccountImageResponse> AddImageAsync(CreateAccountImageRequest createAccountImageRequest, string currentPath)
    {
        await _accountBusinessRules.IsExistsAccount(createAccountImageRequest.Id);

        /* Server */

        #region
        //var uploadResult = _fileHelper.Add(createAccountImageRequest.File, currentPath);
        //string newFolderPath = uploadResult.Result.Replace(currentPath, PathConstant.ImagePath);
        //Account account = await _accountDal.GetAsync(predicate: a => a.Id == createAccountImageRequest.Id, enableTracking: false);
        //account.ProfilePhotoPath = newFolderPath;

        //Account addedAccount = await _accountDal.UpdateAsync(account);
        //CreatedAccountImageResponse createdAccountImageResponse = _mapper.Map<CreatedAccountImageResponse>(addedAccount);
        //return createdAccountImageResponse;
        #endregion

        /* Localhost */

        #region
        string folderPath = currentPath.Replace(currentPath, PathConstant.LocalImagePath);
        string addResult = await _fileHelper.Add(createAccountImageRequest.File, folderPath);
        string newFolderPath = addResult.Replace(folderPath, PathConstant.LocalBaseUrlImagePath);

        Account account = await _accountDal.GetAsync(predicate: a => a.Id == createAccountImageRequest.Id, enableTracking: false);
        account.ProfilePhotoPath = newFolderPath;

        Account addedAccount = await _accountDal.UpdateAsync(account);
        CreatedAccountImageResponse createdAccountImageResponse = _mapper.Map<CreatedAccountImageResponse>(addedAccount);
        return createdAccountImageResponse;
        #endregion
    }

    public async Task<DeletedAccountResponse> DeleteImageAsync(Guid id)
    {
        /* Server */

        #region
        //await _accountBusinessRules.IsExistsAccount(id);
        //Account account = await _accountDal.GetAsync(predicate: l => l.Id == id);
        //await _fileHelper.Delete(account.ProfilePhotoPath);
        //account.ProfilePhotoPath = null;
        //Account deletedAccount = await _accountDal.UpdateAsync(account);
        //DeletedAccountResponse deletedAccountResponse = _mapper.Map<DeletedAccountResponse>(deletedAccount);
        //return deletedAccountResponse;
        #endregion

        /* Localhost */

        #region
        await _accountBusinessRules.IsExistsAccount(id);
        Account account = await _accountDal.GetAsync(predicate: l => l.Id == id);
        string accountProfilePath = PathConstant.LocalImagePath + account.ProfilePhotoPath.Substring(PathConstant.LocalBaseUrlImagePath.Length);
        await _fileHelper.Delete(accountProfilePath);
        account.ProfilePhotoPath = null;
        Account deletedAccount = await _accountDal.UpdateAsync(account);
        DeletedAccountResponse deletedAccountResponse = _mapper.Map<DeletedAccountResponse>(deletedAccount);
        return deletedAccountResponse;
        #endregion
    }
}
