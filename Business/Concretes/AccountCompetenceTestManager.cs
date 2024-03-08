using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.AccountCompetenceTestRequests;
using Business.Dtos.Responses.AccountCompetenceTestResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class AccountCompetenceTestManager : IAccountCompetenceTestService
{
    IAccountCompetenceTestDal _accountCompetenceTestDal;
    IMapper _mapper;

    public AccountCompetenceTestManager(IAccountCompetenceTestDal accountCompetenceTestDal, IMapper mapper)
    {
        _accountCompetenceTestDal = accountCompetenceTestDal;
        _mapper = mapper;
    }

    public async Task<CreatedAccountCompetenceTestResponse> AddAsync(CreateAccountCompetenceTestRequest createAccountCompetenceTestRequest)
    {
        AccountCompetenceTest accountCompetenceTest = _mapper.Map<AccountCompetenceTest>(createAccountCompetenceTestRequest);
        AccountCompetenceTest createdAccountCompetenceTest = await _accountCompetenceTestDal.AddAsync(accountCompetenceTest);
        CreatedAccountCompetenceTestResponse createdAccountCompetenceTestResponse = _mapper.Map<CreatedAccountCompetenceTestResponse>(createdAccountCompetenceTest);
        return createdAccountCompetenceTestResponse;
    }

    public async Task<DeletedAccountCompetenceTestResponse> DeleteAsync(DeleteAccountCompetenceTestRequest deleteAccountCompetenceTestRequest)
    {
        //await _cityBusinessRules.IsExistsCity(deleteCityRequest.Id);
        AccountCompetenceTest accountCompetenceTest = await _accountCompetenceTestDal.GetAsync(predicate: c => c.Id == deleteAccountCompetenceTestRequest.Id);
        AccountCompetenceTest deletedAccountCompetenceTest = await _accountCompetenceTestDal.DeleteAsync(accountCompetenceTest);
        DeletedAccountCompetenceTestResponse deletedAccountCompetenceTestResponse = _mapper.Map<DeletedAccountCompetenceTestResponse>(deletedAccountCompetenceTest);
        return deletedAccountCompetenceTestResponse;
    }


    public async Task<GetAccountCompetenceTestResponse> GetByIdAsync(Guid Id)
    {
        var accountCompetenceTest = await _accountCompetenceTestDal.GetAsync(d => d.Id == Id);
        var mappedAccountCompetenceTest = _mapper.Map<GetAccountCompetenceTestResponse>(accountCompetenceTest);
        return mappedAccountCompetenceTest;
    }

    public async Task<IPaginate<GetListAccountCompetenceTestResponse>> GetListAsync(PageRequest pageRequest)
    {
        var accountCompetenceTest = await _accountCompetenceTestDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedAccountCompetenceTest = _mapper.Map<Paginate<GetListAccountCompetenceTestResponse>>(accountCompetenceTest);
        return mappedAccountCompetenceTest;
    }

    public async Task<UpdatedAccountCompetenceTestResponse> UpdateAsync(UpdateAccountCompetenceTestRequest updateAccountCompetenceTestRequest)
    {
        AccountCompetenceTest accountCompetenceTest = _mapper.Map<AccountCompetenceTest>(updateAccountCompetenceTestRequest);
        AccountCompetenceTest updatedAccountCompetenceTest = await _accountCompetenceTestDal.UpdateAsync(accountCompetenceTest);
        UpdatedAccountCompetenceTestResponse updatedAccountCompetenceTestResponse = _mapper.Map<UpdatedAccountCompetenceTestResponse>(updatedAccountCompetenceTest);
        return updatedAccountCompetenceTestResponse;
    }
}
