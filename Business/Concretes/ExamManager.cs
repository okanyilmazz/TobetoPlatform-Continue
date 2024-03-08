using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ExamRequests;
using Business.Dtos.Responses.ExamResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ExamManager : IExamService
{
    IExamDal _examDal;
    ExamBusinessRules _examBusinessRules;
    IMapper _mapper;
    IOccupationClassService _occupationClassService;

    public ExamManager(IExamDal examDal, IMapper mapper, ExamBusinessRules examBusinessRules, IOccupationClassService occupationClassService)
    {
        _examDal = examDal;
        _mapper = mapper;
        _examBusinessRules = examBusinessRules;
        _occupationClassService = occupationClassService;
    }
    public async Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest)
    {
        var exam = _mapper.Map<Exam>(createExamRequest);
        var addedExam = await _examDal.AddAsync(exam);
        var responseExam = _mapper.Map<CreatedExamResponse>(addedExam);
        return responseExam;
    }

    public async Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest)
    {
        await _examBusinessRules.IsExistsExam(deleteExamRequest.Id);
        Exam exam = await _examDal.GetAsync(predicate: e => e.Id == deleteExamRequest.Id);
        Exam deletedExam = await _examDal.DeleteAsync(exam);
        DeletedExamResponse deletedExamResponse = _mapper.Map<DeletedExamResponse>(deletedExam);
        return deletedExamResponse;
    }

    public async Task<GetListExamResponse> GetByIdAsync(Guid id)
    {
        var exam = await _examDal.GetAsync(h => h.Id == id);
        return _mapper.Map<GetListExamResponse>(exam);
    }

    public async Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest)
    {
        var exams = await _examDal.GetListAsync(
            include: e => e.Include(e => e.ExamQuestions).ThenInclude(eq => eq.Question).ThenInclude(q => q.QuestionType),
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedExams = _mapper.Map<Paginate<GetListExamResponse>>(exams);
        return mappedExams;
    }

    public async Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest)
    {
        Exam exam = _mapper.Map<Exam>(updateExamRequest);
        Exam updatedExam = await _examDal.UpdateAsync(exam);
        UpdatedExamResponse updatedExamResponse = _mapper.Map<UpdatedExamResponse>(updatedExam);
        return updatedExamResponse;
    }

    public async Task<IPaginate<GetListExamResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest)
    {
        var occupationClass = await _occupationClassService.GetByAccountIdAsync(accountId);

        var exams = await _examDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize,
            include: e => e
            .Include(e => e.ExamOccupationClasses)
            .Include(e => e.ExamQuestions).ThenInclude(eq => eq.Question).ThenInclude(q => q.QuestionType),
            predicate: e => e.ExamOccupationClasses.Any(eoc => eoc.OccupationClassId == occupationClass.Id));
        var mappedExams = _mapper.Map<Paginate<GetListExamResponse>>(exams);
        return mappedExams;
    }
}