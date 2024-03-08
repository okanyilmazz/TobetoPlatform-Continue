using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ExamQuestionRequests;
using Business.Dtos.Responses.ExamQuestionResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ExamQuestionManager : IExamQuestionService
{
    IExamQuestionDal _examQuestionDal;
    IMapper _mapper;
    ExamQuestionBusinessRules _examQuestionBusinessRules;

    public ExamQuestionManager(IExamQuestionDal examQuestionDal, IMapper mapper, ExamQuestionBusinessRules examQuestionBusinessRules)
    {
        _examQuestionDal = examQuestionDal;
        _mapper = mapper;
        _examQuestionBusinessRules = examQuestionBusinessRules;
    }

    public async Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest)
    {
        ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(createExamQuestionRequest);
        ExamQuestion addedExamQuestion = await _examQuestionDal.AddAsync(examQuestion);
        CreatedExamQuestionResponse createdExamQuestionResponse = _mapper.Map<CreatedExamQuestionResponse>(addedExamQuestion);
        return createdExamQuestionResponse;
    }

    public async Task<DeletedExamQuestionResponse> DeleteAsync(DeleteExamQuestionRequest deleteExamQuestionRequest)
    {
        await _examQuestionBusinessRules.IsExistsExamQuestion(deleteExamQuestionRequest.Id);
        ExamQuestion examQuestion = await _examQuestionDal.GetAsync(predicate: a => a.Id == deleteExamQuestionRequest.Id);
        ExamQuestion deletedExamQuestion = await _examQuestionDal.DeleteAsync(examQuestion);
        DeletedExamQuestionResponse createdExamQuestionResponse = _mapper.Map<DeletedExamQuestionResponse>(deletedExamQuestion);
        return createdExamQuestionResponse;
    }

    public async Task<GetListExamQuestionResponse> GetByIdAsync(Guid id)
    {
        var examQuestion = await _examQuestionDal.GetAsync(
             predicate: e => e.Id == id,
             include: eq => eq.
             Include(eq => eq.Exam).
             Include(eq => eq.Question));
        var mappedExamQuestion = _mapper.Map<GetListExamQuestionResponse>(examQuestion);
        return mappedExamQuestion;
    }

    public async Task<IPaginate<GetListExamQuestionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var examQuestions = await _examQuestionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: eq => eq.
            Include(eq => eq.Exam).
            Include(eq => eq.Question));
        var mappedExamQuestions = _mapper.Map<Paginate<GetListExamQuestionResponse>>(examQuestions);
        return mappedExamQuestions;
    }

    public async Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest)
    {
        await _examQuestionBusinessRules.IsExistsExamQuestion(updateExamQuestionRequest.Id);
        ExamQuestion examQuestion = _mapper.Map<ExamQuestion>(updateExamQuestionRequest);
        ExamQuestion updatedExamQuestion = await _examQuestionDal.UpdateAsync(examQuestion);
        UpdatedExamQuestionResponse updatedExamQuestionResponse = _mapper.Map<UpdatedExamQuestionResponse>(updatedExamQuestion);
        return updatedExamQuestionResponse;
    }
}