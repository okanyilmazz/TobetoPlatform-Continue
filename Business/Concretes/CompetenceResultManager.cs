using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CompetenceResultRequests;
using Business.Dtos.Responses.CompetenceResultResponses;
using Business.Dtos.Responses.ExamResultResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes;

public class CompetenceResultManager : ICompetenceResultService
{
    ICompetenceResultDal _competenceResultDal;
    IMapper _mapper;
    public CompetenceResultManager(ICompetenceResultDal competenceResultDal, IMapper mapper)
    {
        _competenceResultDal = competenceResultDal;
        _mapper = mapper;
    }

    public async Task<CreatedCompetenceResultResponse> AddAsync(CreateCompetenceResultRequest createCompetenceResultRequest)
    {
        CompetenceResult competenceResult = _mapper.Map<CompetenceResult>(createCompetenceResultRequest);
        CompetenceResult createdCompetenceResult = await _competenceResultDal.AddAsync(competenceResult);
        CreatedCompetenceResultResponse createdCompetenceResultResponse = _mapper.Map<CreatedCompetenceResultResponse>(createdCompetenceResult);
        return createdCompetenceResultResponse;
    }

    public async Task<DeletedCompetenceResultResponse> DeleteAsync(DeleteCompetenceResultRequest deleteCompetenceResultRequest)
    {
        CompetenceResult competenceResult = await _competenceResultDal.GetAsync(predicate: c => c.Id == deleteCompetenceResultRequest.Id);
        CompetenceResult deletedCompetenceResult = await _competenceResultDal.DeleteAsync(competenceResult);
        DeletedCompetenceResultResponse deletedCompetenceResultResponse = _mapper.Map<DeletedCompetenceResultResponse>(deletedCompetenceResult);
        return deletedCompetenceResultResponse;
    }

    public async Task<IPaginate<GetListCompetenceResultResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var competenceResult = await _competenceResultDal.GetListAsync(a => a.AccountId == accountId);
        var mappedCompetenceResult = _mapper.Map<Paginate<GetListCompetenceResultResponse>>(competenceResult);
        return mappedCompetenceResult;
    }

    public async Task<GetListCompetenceResultResponse> GetByIdAsync(Guid id)
    {
        var competenceResult = await _competenceResultDal.GetAsync(p => p.Id == id);
        var mappedCompetenceResult = _mapper.Map<GetListCompetenceResultResponse>(competenceResult);
        return mappedCompetenceResult;
    }

    public async Task<IPaginate<GetListCompetenceResultResponse>> GetListAsync(PageRequest pageRequest)
    {
        var competenceResult = await _competenceResultDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedCompetenceResult = _mapper.Map<Paginate<GetListCompetenceResultResponse>>(competenceResult);
        return mappedCompetenceResult;
    }

    public async Task<UpdatedCompetenceResultResponse> UpdateAsync(UpdateCompetenceResultRequest updateCompetenceResultRequest)
    {
        CompetenceResult competenceResult = _mapper.Map<CompetenceResult>(updateCompetenceResultRequest);
        CompetenceResult updatedCompetenceResult = await _competenceResultDal.UpdateAsync(competenceResult);
        UpdatedCompetenceResultResponse updatedCompetenceResultResponse = _mapper.Map<UpdatedCompetenceResultResponse>(updatedCompetenceResult);
        return updatedCompetenceResultResponse;
    }
}
