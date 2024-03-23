using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CompetenceTestRequests;
using Business.Dtos.Responses.CompetenceTestResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CompetenceTestManager : ICompetenceTestService
{
    ICompetenceTestDal _competenceTestDal;
    CompetenceTestBusinessRules _competenceTestBusinessRules;
    IMapper _mapper;

    public CompetenceTestManager(ICompetenceTestDal competenceTestDal, IMapper mapper, CompetenceTestBusinessRules competenceTestBusinessRules)
    {
        _competenceTestDal = competenceTestDal;
        _mapper = mapper;
        _competenceTestBusinessRules = competenceTestBusinessRules;
    }
    public async Task<CreatedCompetenceTestResponse> AddAsync(CreateCompetenceTestRequest createCompetenceTestRequest)
    {
        var competenceTest = _mapper.Map<CompetenceTest>(createCompetenceTestRequest);
        var addedCompetenceTest = await _competenceTestDal.AddAsync(competenceTest);
        var responseCompetenceTest = _mapper.Map<CreatedCompetenceTestResponse>(addedCompetenceTest);
        return responseCompetenceTest;
    }

    public async Task<DeletedCompetenceTestResponse> DeleteAsync(Guid id)
    {
        await _competenceTestBusinessRules.IsExistsCompetenceTest(id);
        CompetenceTest competenceTest = await _competenceTestDal.GetAsync(predicate: ct => ct.Id == id);
        CompetenceTest deletedCompetenceTest = await _competenceTestDal.DeleteAsync(competenceTest);
        DeletedCompetenceTestResponse deletedCompetenceTestResponse = _mapper.Map<DeletedCompetenceTestResponse>(deletedCompetenceTest);
        return deletedCompetenceTestResponse;
    }

    public async Task<GetCompetenceTestResponse> GetByIdAsync(Guid id)
    {
        var competenceTest = await _competenceTestDal.GetAsync(ct => ct.Id == id);
        return _mapper.Map<GetCompetenceTestResponse>(competenceTest);
    }

    public async Task<IPaginate<GetListCompetenceTestResponse>> GetListAsync(PageRequest pageRequest)
    {
        var competenceTests = await _competenceTestDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedCompetenceTests = _mapper.Map<Paginate<GetListCompetenceTestResponse>>(competenceTests);
        return mappedCompetenceTests;
    }

    public async Task<UpdatedCompetenceTestResponse> UpdateAsync(UpdateCompetenceTestRequest updateCompetenceTestRequest)
    {
        CompetenceTest competenceTest = _mapper.Map<CompetenceTest>(updateCompetenceTestRequest);
        CompetenceTest updatedCompetenceTest = await _competenceTestDal.UpdateAsync(competenceTest);
        UpdatedCompetenceTestResponse updatedCompetenceTestResponse = _mapper.Map<UpdatedCompetenceTestResponse>(updatedCompetenceTest);
        return updatedCompetenceTestResponse;
    }

    public async Task<IPaginate<GetListCompetenceTestResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var competenceTests = await _competenceTestDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize,
            include: ct => ct
            .Include(ct  => ct.AccountCompetenceTests)
            .Include(ct => ct.CompetenceTestQuestions).ThenInclude(ctq => ctq.CompetenceQuestion).ThenInclude(cq => cq.CompetenceCategory),
            predicate: ct => ct.AccountCompetenceTests.Any(act => act.AccountId == accountId)
            );
        var mappedCompetenceTests = _mapper.Map<Paginate<GetListCompetenceTestResponse>>(competenceTests);
        return mappedCompetenceTests;
    }
}