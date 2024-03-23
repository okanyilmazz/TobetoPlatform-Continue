using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.QuestionRequests;
using Business.Dtos.Responses.QuestionResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class QuestionManager : IQuestionService
{
    IQuestionDal _questionDal;
    IMapper _mapper;
    QuestionBusinessRules _questionBusinessRules;

    public QuestionManager(IQuestionDal questionDal, IMapper mapper, QuestionBusinessRules questionBusinessRules)
    {
        _questionDal = questionDal;
        _mapper = mapper;
        _questionBusinessRules = questionBusinessRules;
    }
    public async Task<CreatedQuestionResponse> AddAsync(CreateQuestionRequest createQuestionRequest)
    {
        Question question = _mapper.Map<Question>(createQuestionRequest);
        Question addedQuestion = await _questionDal.AddAsync(question);
        CreatedQuestionResponse createdQuestionResponse = _mapper.Map<CreatedQuestionResponse>(addedQuestion);
        return createdQuestionResponse;

    }

    public async Task<DeletedQuestionResponse> DeleteAsync(Guid id)
    {
        await _questionBusinessRules.IsExistsQuestion(id);
        Question question = await _questionDal.GetAsync(predicate: a => a.Id == id);
        Question deletedQuestion = await _questionDal.DeleteAsync(question);
        DeletedQuestionResponse createdQuestionResponse = _mapper.Map<DeletedQuestionResponse>(deletedQuestion);
        return createdQuestionResponse;
    }

    public async Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var questions = await _questionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
            );
        var mappedQuestions = _mapper.Map<Paginate<GetListQuestionResponse>>(questions);
        return mappedQuestions;
    }

    public async Task<GetQuestionResponse> GetByIdAsync(Guid id)
    {
        var question = await _questionDal.GetAsync(q => q.Id == id);
        var mappedQuestion = _mapper.Map<GetQuestionResponse>(question);
        return mappedQuestion;
    }

    public async Task<UpdatedQuestionResponse> UpdateAsync(UpdateQuestionRequest updateQuestionRequest)
    {
        await _questionBusinessRules.IsExistsQuestion(updateQuestionRequest.Id);
        Question question = _mapper.Map<Question>(updateQuestionRequest);
        Question updatedQuestion = await _questionDal.UpdateAsync(question);
        UpdatedQuestionResponse updatedQuestionResponse = _mapper.Map<UpdatedQuestionResponse>(updatedQuestion);
        return updatedQuestionResponse;
    }

    public async Task<IPaginate<GetListQuestionResponse>> GetByExamIdAsync(Guid examId, PageRequest pageRequest)
    {
        var questionsList = await _questionDal.GetListAsync(
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize,
             include: q => q.Include(e => e.ExamQuestions).ThenInclude(eq => eq.Exam),
             predicate: q => q.ExamQuestions.Any(eq => eq.ExamId == examId));

        var mappedQuestions = _mapper.Map<Paginate<GetListQuestionResponse>>(questionsList);
        return mappedQuestions;
    }
}
