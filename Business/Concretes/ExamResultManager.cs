using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ExamResultRequests;
using Business.Dtos.Responses.ExamResultResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ExamResultManager : IExamResultService
{
    IExamResultDal _examResultDal;
    IMapper _mapper;
    ExamResultBusinessRules _examResultBusinessRules;

    public ExamResultManager(IExamResultDal examResultDal, IMapper mapper, ExamResultBusinessRules examResultBusinessRules)
    {
        _examResultDal = examResultDal;
        _mapper = mapper;
        _examResultBusinessRules = examResultBusinessRules;
    }

    public async Task<CreatedExamResultResponse> AddAsync(CreateExamResultRequest createExamResultRequest)
    {
        ExamResult examResult = _mapper.Map<ExamResult>(createExamResultRequest);
        ExamResult addedExamResult = await _examResultDal.AddAsync(examResult);
        CreatedExamResultResponse createdExamResultResponse = _mapper.Map<CreatedExamResultResponse>(addedExamResult);
        return createdExamResultResponse;
    }

    public async Task<IPaginate<GetListExamResultResponse>> GetListAsync(PageRequest pageRequest)
    {
        var examResult = await _examResultDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: er => er.Include(er => er.Exam)
            );
        var mappedExamResults = _mapper.Map<Paginate<GetListExamResultResponse>>(examResult);
        return mappedExamResults;
    }

    public async Task<DeletedExamResultResponse> DeleteAsync(DeleteExamResultRequest deleteExamResultRequest)
    {
        await _examResultBusinessRules.IsExistsExamResult(deleteExamResultRequest.Id);
        ExamResult examResult = await _examResultDal.GetAsync(predicate: er => er.Id == deleteExamResultRequest.Id);
        ExamResult deletedExamResult = await _examResultDal.DeleteAsync(examResult);
        DeletedExamResultResponse deletedExamResultResponse = _mapper.Map<DeletedExamResultResponse>(examResult);
        return deletedExamResultResponse;
    }

    public async Task<UpdatedExamResultResponse> UpdateAsync(UpdateExamResultRequest updateExamResultRequest)
    {
        await _examResultBusinessRules.IsExistsExamResult(updateExamResultRequest.Id);
        ExamResult examResult = _mapper.Map<ExamResult>(updateExamResultRequest);
        ExamResult updatedExamResult = await _examResultDal.UpdateAsync(examResult);
        UpdatedExamResultResponse updatedExamResultResponse = _mapper.Map<UpdatedExamResultResponse>(updatedExamResult);
        return updatedExamResultResponse;
    }

    public async Task<GetExamResultResponse> GetByIdAsync(Guid id)
    {
        var examResult = await _examResultDal.GetAsync(
            predicate: er => er.Id == id,
            include: er => er.Include(er => er.Exam));        
        return _mapper.Map<GetExamResultResponse>(examResult);
    }

    public async Task<IPaginate<GetListExamResultResponse>> GetByAccountIdAsync(Guid accountId)
    {
        var examresult = await _examResultDal.GetListAsync(
            predicate:a => a.AccountId == accountId,
            include: er => er.Include(er => er.Exam));                    
        var mappedExamResult = _mapper.Map<Paginate<GetListExamResultResponse>>(examresult);
        return mappedExamResult;
    }
}