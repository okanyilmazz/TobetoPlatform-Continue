using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CompetenceTestQuestionRequests;
using Business.Dtos.Responses.CompetenceTestQuestionResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class CompetenceTestQuestionManager : ICompetenceTestQuestionService
{
    ICompetenceTestQuestionDal _competenceTestQuestionDal;
    IMapper _mapper;
    CompetenceTestQuestionBusinessRules _competenceTestQuestionBusinessRules;

    public CompetenceTestQuestionManager(ICompetenceTestQuestionDal competenceTestQuestionDal, IMapper mapper, CompetenceTestQuestionBusinessRules competenceTestQuestionBusinessRules)
    {
        _competenceTestQuestionDal = competenceTestQuestionDal;
        _mapper = mapper;
        _competenceTestQuestionBusinessRules = competenceTestQuestionBusinessRules;
    }

    public async Task<CreatedCompetenceTestQuestionResponse> AddAsync(CreateCompetenceTestQuestionRequest createCompetenceTestQuestionRequest)
    {
        CompetenceTestQuestion competenceTestQuestion = _mapper.Map<CompetenceTestQuestion>(createCompetenceTestQuestionRequest);
        CompetenceTestQuestion addedCompetenceTestQuestion = await _competenceTestQuestionDal.AddAsync(competenceTestQuestion);
        CreatedCompetenceTestQuestionResponse createdCompetenceTestQuestionResponse = _mapper.Map<CreatedCompetenceTestQuestionResponse>(addedCompetenceTestQuestion);
        return createdCompetenceTestQuestionResponse;
    }

    public async Task<DeletedCompetenceTestQuestionResponse> DeleteAsync(Guid id)
    {
        await _competenceTestQuestionBusinessRules.IsExistsCompetenceTestQuestion(id);
        CompetenceTestQuestion competenceTestQuestion = await _competenceTestQuestionDal.GetAsync(predicate: a => a.Id == id);
        CompetenceTestQuestion deletedCompetenceTestQuestion = await _competenceTestQuestionDal.DeleteAsync(competenceTestQuestion);
        DeletedCompetenceTestQuestionResponse createdCompetenceTestQuestionResponse = _mapper.Map<DeletedCompetenceTestQuestionResponse>(deletedCompetenceTestQuestion);
        return createdCompetenceTestQuestionResponse;
    }

    public async Task<GetCompetenceTestQuestionResponse> GetByIdAsync(Guid id)
    {
        var competenceTestQuestion = await _competenceTestQuestionDal.GetAsync(
             predicate: ctq => ctq.Id == id,
             include: ctq => ctq.
             Include(ctq => ctq.CompetenceTest).
             Include(ctq => ctq.CompetenceQuestion));
        var mappedCompetenceTestQuestion = _mapper.Map<GetCompetenceTestQuestionResponse>(competenceTestQuestion);
        return mappedCompetenceTestQuestion;
    }

    public async Task<IPaginate<GetListCompetenceTestQuestionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var competenceTestQuestions = await _competenceTestQuestionDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: ctq => ctq.
            Include(ctq => ctq.CompetenceTest).
            Include(ctq => ctq.CompetenceQuestion));
        var mappedCompetenceTestQuestions = _mapper.Map<Paginate<GetListCompetenceTestQuestionResponse>>(competenceTestQuestions);
        return mappedCompetenceTestQuestions;
    }

    public async Task<UpdatedCompetenceTestQuestionResponse> UpdateAsync(UpdateCompetenceTestQuestionRequest updateCompetenceTestQuestionRequest)
    {
        await _competenceTestQuestionBusinessRules.IsExistsCompetenceTestQuestion(updateCompetenceTestQuestionRequest.Id);
        CompetenceTestQuestion competenceTestQuestion = _mapper.Map<CompetenceTestQuestion>(updateCompetenceTestQuestionRequest);
        CompetenceTestQuestion updatedCompetenceTestQuestion = await _competenceTestQuestionDal.UpdateAsync(competenceTestQuestion);
        UpdatedCompetenceTestQuestionResponse updatedCompetenceTestQuestionResponse = _mapper.Map<UpdatedCompetenceTestQuestionResponse>(updatedCompetenceTestQuestion);
        return updatedCompetenceTestQuestionResponse;
    }
}