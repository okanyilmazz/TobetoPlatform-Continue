using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ExamQuestionTypeRequests;
using Business.Dtos.Responses.ExamQuestionTypeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class ExamQuestionTypeManager : IExamQuestionTypeService
{
    IExamQuestionTypeDal _examQuestionTypeDal;
    IMapper _mapper;
    ExamQuestionTypeBusinessRules _examQuestionTypeBusinessRules;

    public ExamQuestionTypeManager(IExamQuestionTypeDal examQuestionTypeDal, IMapper mapper, ExamQuestionTypeBusinessRules examQuestionTypeBusinessRules)
    {
        _examQuestionTypeDal = examQuestionTypeDal;
        _mapper = mapper;
        _examQuestionTypeBusinessRules = examQuestionTypeBusinessRules;
    }

    public async Task<CreatedExamQuestionTypeResponse> AddAsync(CreateExamQuestionTypeRequest createExamQuestionTypeRequest)
    {
        ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(createExamQuestionTypeRequest);
        ExamQuestionType addedExamQuestionType = await _examQuestionTypeDal.AddAsync(examQuestionType);
        CreatedExamQuestionTypeResponse createdExamQuestionTypeResponse = _mapper.Map<CreatedExamQuestionTypeResponse>(addedExamQuestionType);
        return createdExamQuestionTypeResponse;
    }

    public async Task<DeletedExamQuestionTypeResponse> DeleteAsync(Guid id)
    {
        await _examQuestionTypeBusinessRules.IsExistsExamQuestionType(id);
        ExamQuestionType examQuestionType= await _examQuestionTypeDal.GetAsync(predicate: eq => eq.Id == id);
        ExamQuestionType deletedExamQuestionType = await _examQuestionTypeDal.DeleteAsync(examQuestionType);
        DeletedExamQuestionTypeResponse deletedExamQuestionTypeResponse = _mapper.Map<DeletedExamQuestionTypeResponse>(examQuestionType);
        return deletedExamQuestionTypeResponse;

    }

    public async Task<GetExamQuestionTypeResponse> GetByIdAsync(Guid id)
    {
        var examQuestionType = await _examQuestionTypeDal.GetAsync(
            predicate: eqt => eqt.Id == id,
            include: eqt => eqt
            .Include(eqt => eqt.QuestionType)
            .Include(eqt => eqt.Exam));
        return _mapper.Map<GetExamQuestionTypeResponse>(examQuestionType);
    }

    public async Task<IPaginate<GetListExamQuestionTypeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var examQuestionType = await _examQuestionTypeDal.GetListAsync(
            index:pageRequest.PageIndex,
            size:pageRequest.PageSize,
            include: eqt => eqt
            .Include(eqt => eqt.QuestionType)
            .Include(eqt => eqt.Exam));
        var mappedExamQuestionType = _mapper.Map<Paginate<GetListExamQuestionTypeResponse>>(examQuestionType);
        return mappedExamQuestionType;
    }

    public async Task<UpdatedExamQuestionTypeResponse> UpdateAsync(UpdateExamQuestionTypeRequest updateExamQuestionTypeRequest)
    {
        await _examQuestionTypeBusinessRules.IsExistsExamQuestionType(updateExamQuestionTypeRequest.Id);
        ExamQuestionType examQuestionType = _mapper.Map<ExamQuestionType>(updateExamQuestionTypeRequest);
        ExamQuestionType updatedExamQuestionType = await _examQuestionTypeDal.UpdateAsync(examQuestionType);
        UpdatedExamQuestionTypeResponse updatedExamQuestionTypeResponse = _mapper.Map<UpdatedExamQuestionTypeResponse>(updatedExamQuestionType);
        return updatedExamQuestionTypeResponse;
    }
}
