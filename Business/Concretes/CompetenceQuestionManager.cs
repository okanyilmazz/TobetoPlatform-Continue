using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CompetenceQuestionRequests;
using Business.Dtos.Responses.CompetenceQuestionResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CompetenceQuestionManager : ICompetenceQuestionService
{
    ICompetenceQuestionDal _competenceQuestionDal;
    IMapper _mapper;
    public CompetenceQuestionManager(ICompetenceQuestionDal competenceQuestionDal, IMapper mapper)
    {
        _competenceQuestionDal = competenceQuestionDal;
        _mapper = mapper;
    }

    public async Task<CreatedCompetenceQuestionResponse> AddAsync(CreateCompetenceQuestionRequest createCompetenceQuestionRequest)
    {
        CompetenceQuestion CompetenceQuestion = _mapper.Map<CompetenceQuestion>(createCompetenceQuestionRequest);
        CompetenceQuestion createdCompetenceQuestion = await _competenceQuestionDal.AddAsync(CompetenceQuestion);
        CreatedCompetenceQuestionResponse createdCompetenceQuestionResponse = _mapper.Map<CreatedCompetenceQuestionResponse>(createdCompetenceQuestion);
        return createdCompetenceQuestionResponse;
    }

    public async Task<DeletedCompetenceQuestionResponse> DeleteAsync(DeleteCompetenceQuestionRequest deleteCompetenceQuestionRequest)
    {
        CompetenceQuestion CompetenceQuestion = await _competenceQuestionDal.GetAsync(predicate: c => c.Id == deleteCompetenceQuestionRequest.Id);
        CompetenceQuestion deletedCompetenceQuestion = await _competenceQuestionDal.DeleteAsync(CompetenceQuestion);
        DeletedCompetenceQuestionResponse deletedCompetenceQuestionResponse = _mapper.Map<DeletedCompetenceQuestionResponse>(deletedCompetenceQuestion);
        return deletedCompetenceQuestionResponse;
    }

    public async Task<GetCompetenceQuestionResponse> GetByIdAsync(Guid id)
    {
        var CompetenceQuestion = await _competenceQuestionDal.GetAsync(p => p.Id == id);
        var mappedCompetenceQuestion = _mapper.Map<GetCompetenceQuestionResponse>(CompetenceQuestion);
        return mappedCompetenceQuestion;
    }

    public async Task<IPaginate<GetListCompetenceQuestionResponse>> GetListAsync(PageRequest pageRequest)
    {
        var CompetenceQuestion = await _competenceQuestionDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedCompetenceQuestion = _mapper.Map<Paginate<GetListCompetenceQuestionResponse>>(CompetenceQuestion);
        return mappedCompetenceQuestion;
    }

    public async Task<UpdatedCompetenceQuestionResponse> UpdateAsync(UpdateCompetenceQuestionRequest updateCompetenceQuestionRequest)
    {
        CompetenceQuestion CompetenceQuestion = _mapper.Map<CompetenceQuestion>(updateCompetenceQuestionRequest);
        CompetenceQuestion updatedCompetenceQuestion = await _competenceQuestionDal.UpdateAsync(CompetenceQuestion);
        UpdatedCompetenceQuestionResponse updatedCompetenceQuestionResponse = _mapper.Map<UpdatedCompetenceQuestionResponse>(updatedCompetenceQuestion);
        return updatedCompetenceQuestionResponse;
    }
}