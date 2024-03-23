using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ExamOccupationClassRequests;
using Business.Dtos.Responses.ExamOccupationClassResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ExamOccupationClassManager : IExamOccupationClassService
{
    IExamOccupationClassDal _examOccupationClassDal;
    IMapper _mapper;
    ExamOccupationClassBusinessRules _examOccupationClassBusinessRules;


    public ExamOccupationClassManager(IExamOccupationClassDal examOccupationClassDal, IMapper mapper, ExamOccupationClassBusinessRules examOccupationClassBusinessRules)
    {
        _examOccupationClassDal = examOccupationClassDal;
        _mapper = mapper;
        _examOccupationClassBusinessRules = examOccupationClassBusinessRules;
    }

    public async Task<CreatedExamOccupationClassResponse> AddAsync(CreateExamOccupationClassRequest createExamOccupationClassRequest)
    {
        ExamOccupationClass examOccupationClass = _mapper.Map<ExamOccupationClass>(createExamOccupationClassRequest);
        ExamOccupationClass createdExamOccupationClass = await _examOccupationClassDal.AddAsync(examOccupationClass);
        CreatedExamOccupationClassResponse createdExamOccupationClassResponse = _mapper.Map<CreatedExamOccupationClassResponse>(createdExamOccupationClass);
        return createdExamOccupationClassResponse;
    }

    public async Task<DeletedExamOccupationClassResponse> DeleteAsync(Guid id)
    {
        await _examOccupationClassBusinessRules.IsExistsExamOccupationClass(id);
        ExamOccupationClass examOccupationClass = await _examOccupationClassDal.GetAsync(predicate: eoc => eoc.Id == id);
        ExamOccupationClass deletedExamOccupationClass = await _examOccupationClassDal.DeleteAsync(examOccupationClass);
        DeletedExamOccupationClassResponse deletedExamOccupationClassResponse = _mapper.Map<DeletedExamOccupationClassResponse>(deletedExamOccupationClass);
        return deletedExamOccupationClassResponse;
    }

    public async Task<GetExamOccupationClassResponse> GetByIdAsync(Guid id)
    {
        var examOccupationClass = await _examOccupationClassDal.GetAsync(
            predicate: eoc => eoc.Id == id,
            include: eoc => eoc
            .Include(eoc => eoc.Exam)
            .Include(eoc => eoc.OccupationClass));
        return _mapper.Map<GetExamOccupationClassResponse>(examOccupationClass);
    }

    public async Task<IPaginate<GetListExamOccupationClassResponse>> GetListAsync(PageRequest pageRequest)
    {
        var examOccupationClasses = await _examOccupationClassDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: eoc => eoc
            .Include(eoc => eoc.Exam)
            .Include(eoc => eoc.OccupationClass));
        var mappedExamOccupationClasses = _mapper.Map<Paginate<GetListExamOccupationClassResponse>>(examOccupationClasses);
        return mappedExamOccupationClasses;
    }

    public async Task<UpdatedExamOccupationClassResponse> UpdateAsync(UpdateExamOccupationClassRequest updateExamOccupationClassRequest)
    {
        await _examOccupationClassBusinessRules.IsExistsExamOccupationClass(updateExamOccupationClassRequest.Id);
        ExamOccupationClass examOccupationClass = _mapper.Map<ExamOccupationClass>(updateExamOccupationClassRequest);
        ExamOccupationClass updatedExamOccupationClass = await _examOccupationClassDal.UpdateAsync(examOccupationClass);
        UpdatedExamOccupationClassResponse updatedExamOccupationClassResponse = _mapper.Map<UpdatedExamOccupationClassResponse>(updatedExamOccupationClass);
        return updatedExamOccupationClassResponse;
    }
}
