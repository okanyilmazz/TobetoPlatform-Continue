using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CompetenceRequests;
using Business.Dtos.Responses.CompetenceResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class CompetenceCategoryManager : ICompetenceCategoryService
{
    ICompetenceCategoryDal _competenceCategoryDal;
    IMapper _mapper;
    public CompetenceCategoryManager(ICompetenceCategoryDal competenceCategoryDal, IMapper mapper)
    {
        _competenceCategoryDal = competenceCategoryDal;
        _mapper = mapper;
    }

    public async Task<CreatedCompetenceCategoryResponse> AddAsync(CreateCompetenceCategoryRequest createCompetenceCategoryRequest)
    {
        CompetenceCategory competenceCategory = _mapper.Map<CompetenceCategory>(createCompetenceCategoryRequest);
        CompetenceCategory createdCompetenceCategory = await _competenceCategoryDal.AddAsync(competenceCategory);
        CreatedCompetenceCategoryResponse createdCompetenceCategoryResponse = _mapper.Map<CreatedCompetenceCategoryResponse>(createdCompetenceCategory);
        return createdCompetenceCategoryResponse;
    }

    public async Task<DeletedCompetenceCategoryResponse> DeleteAsync(DeleteCompetenceCategoryRequest deleteCompetenceCategoryRequest)
    {
        CompetenceCategory competenceCategory = await _competenceCategoryDal.GetAsync(predicate: c => c.Id == deleteCompetenceCategoryRequest.Id);
        CompetenceCategory deletedCompetenceCategory = await _competenceCategoryDal.DeleteAsync(competenceCategory);
        DeletedCompetenceCategoryResponse deletedCompetenceCategoryResponse = _mapper.Map<DeletedCompetenceCategoryResponse>(deletedCompetenceCategory);
        return deletedCompetenceCategoryResponse;
    }

    public async Task<GetCompetenceCategoryResponse> GetByIdAsync(Guid id)
    {
        var competenceCategory = await _competenceCategoryDal.GetAsync(p => p.Id == id);
        var mappedCompetenceCategory = _mapper.Map<GetCompetenceCategoryResponse>(competenceCategory);
        return mappedCompetenceCategory;
    }

    public async Task<IPaginate<GetListCompetenceCategoryResponse>> GetListAsync(PageRequest pageRequest)
    {
        var competenceCategory = await _competenceCategoryDal.GetListAsync(
           index: pageRequest.PageIndex,
           size: pageRequest.PageSize);
        var mappedCompetenceCategory = _mapper.Map<Paginate<GetListCompetenceCategoryResponse>>(competenceCategory);
        return mappedCompetenceCategory;
    }

    public async Task<UpdatedCompetenceCategoryResponse> UpdateAsync(UpdateCompetenceCategoryRequest updateCompetenceCategoryRequest)
    {
        CompetenceCategory competenceCategory = _mapper.Map<CompetenceCategory>(updateCompetenceCategoryRequest);
        CompetenceCategory updatedCompetenceCategory = await _competenceCategoryDal.UpdateAsync(competenceCategory);
        UpdatedCompetenceCategoryResponse updatedCompetenceCategoryResponse = _mapper.Map<UpdatedCompetenceCategoryResponse>(updatedCompetenceCategory);
        return updatedCompetenceCategoryResponse;
    }
}