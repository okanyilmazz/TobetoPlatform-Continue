using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.QuestionTypeRequests;
using Business.Dtos.Responses.QuestionTypeResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class QuestionTypeManager : IQuestionTypeService
{
    IQuestionTypeDal _questionTypeDal;
    IQuestionService _questionService;
    IMapper _mapper;
    QuestionTypeBusinessRules _questionTypeBusinessRules;

    public QuestionTypeManager(IQuestionTypeDal questionTypeDal, IMapper mapper, QuestionTypeBusinessRules questionTypeBusinessRules, IQuestionService questionService)
    {
        _questionTypeDal = questionTypeDal;
        _mapper = mapper;
        _questionTypeBusinessRules = questionTypeBusinessRules;
        _questionService = questionService;
    }
    public async Task<CreatedQuestionTypeResponse> AddAsync(CreateQuestionTypeRequest createQuestionTypeRequest)
    {
        QuestionType questionType = _mapper.Map<QuestionType>(createQuestionTypeRequest);
        QuestionType addedQuestionType = await _questionTypeDal.AddAsync(questionType);
        CreatedQuestionTypeResponse createdQuestionTypeResponse = _mapper.Map<CreatedQuestionTypeResponse>(addedQuestionType);
        return createdQuestionTypeResponse;
    }

    public async Task<DeletedQuestionTypeResponse> DeleteAsync(DeleteQuestionTypeRequest deleteQuestionTypeRequest)
    {
        await _questionTypeBusinessRules.IsExistsQuestionType(deleteQuestionTypeRequest.Id);
        QuestionType questionType = await _questionTypeDal.GetAsync(predicate: q => q.Id == deleteQuestionTypeRequest.Id);
        QuestionType deletedQuestionType = await _questionTypeDal.DeleteAsync(questionType, false);
        DeletedQuestionTypeResponse deletedQuestionTypeResponse = _mapper.Map<DeletedQuestionTypeResponse>(deletedQuestionType);
        return deletedQuestionTypeResponse;
    }

    public async Task<GetQuestionTypeResponse> GetByIdAsync(Guid id)
    {
        var questionType = await _questionTypeDal.GetAsync(ud => ud.Id == id);
        var mappedQuestionType = _mapper.Map<GetQuestionTypeResponse>(questionType);
        return mappedQuestionType;
    }

    public async Task<GetQuestionTypeResponse> GetByQuestionIdAsync(Guid questionId)
    {
        var questionType = await _questionTypeDal.GetAsync(
            include: qt => qt.Include(qt => qt.Questions),
            predicate: ud => ud.Questions.Any(q => q.Id == questionId));
        var mappedQuestionType = _mapper.Map<GetQuestionTypeResponse>(questionType);
        return mappedQuestionType;
    }

    public async Task<GetListQuestionTypeNameResponse> GetByExamIdAsync(Guid examId, PageRequest pageRequest)
    {
        var questions = await _questionService.GetByExamIdAsync(examId, pageRequest);
        var uniqueQuestionTypes = new HashSet<string>();

        foreach (var question in questions.Items)
        {
            var questionType = await _questionTypeDal.GetAsync(
                include: qt => qt.Include(qt => qt.Questions),
                predicate: ud => ud.Questions.Any(q => q.Id == question.Id));

            if (!uniqueQuestionTypes.Contains(questionType.Name))
            {
                uniqueQuestionTypes.Add(questionType.Name);
            }
        }

        var response = new GetListQuestionTypeNameResponse
        {
            Names = uniqueQuestionTypes.ToArray()
        };

        return response;
    }

    public async Task<IPaginate<GetListQuestionTypeResponse>> GetListAsync(PageRequest pageRequest)
    {
        var QuestionTypes = await _questionTypeDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
            );
        var mappedQuestionTypes = _mapper.Map<Paginate<GetListQuestionTypeResponse>>(QuestionTypes);
        return mappedQuestionTypes;
    }

    public async Task<UpdatedQuestionTypeResponse> UpdateAsync(UpdateQuestionTypeRequest updateQuestionTypeRequest)
    {
        await _questionTypeBusinessRules.IsExistsQuestionType(updateQuestionTypeRequest.Id);
        QuestionType questionType = _mapper.Map<QuestionType>(updateQuestionTypeRequest);
        QuestionType updatedQuestionType = await _questionTypeDal.UpdateAsync(questionType);
        UpdatedQuestionTypeResponse updatedQuestionTypeResponse = _mapper.Map<UpdatedQuestionTypeResponse>(updatedQuestionType);
        return updatedQuestionTypeResponse;
    }
}