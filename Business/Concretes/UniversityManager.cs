using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.UniversityResquests;
using Business.Dtos.Responses.UniversityResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class UniversityManager : IUniversityService
{
    IUniversityDal _universityDal;
    IMapper _mapper;
    UniversityBusinessRules _universityBusinessRules;

    public UniversityManager(IUniversityDal universityDal, IMapper mapper, UniversityBusinessRules universityBusinessRules)
    {
        _universityDal = universityDal;
        _mapper = mapper;
        _universityBusinessRules = universityBusinessRules;
    }

    public async Task<CreatedUniversityResponse> AddAsync(CreateUniversityRequest createUniversityRequest)
    {
        University university = _mapper.Map<University>(createUniversityRequest);
        University addedUniversity = await _universityDal.AddAsync(university);
        CreatedUniversityResponse createdUniversityResponse = _mapper.Map<CreatedUniversityResponse>(addedUniversity);
        return createdUniversityResponse;
    }

    public async Task<DeletedUniversityResponse> DeleteAsync(DeleteUniversityRequest deleteUniversityRequest)
    {
        await _universityBusinessRules.IsExistsUniversity(deleteUniversityRequest.Id);
        University university = await _universityDal.GetAsync(predicate: u => u.Id == deleteUniversityRequest.Id);
        University deletedUniversity = await _universityDal.DeleteAsync(university);
        DeletedUniversityResponse deletedUniversityResponse = _mapper.Map<DeletedUniversityResponse>(deletedUniversity);
        return deletedUniversityResponse;
    }

    public async Task<GetListUniversityResponse> GetByIdAsync(Guid id)
    {
        var university = await _universityDal.GetAsync(u => u.Id == id);
        var mappedUniversity = _mapper.Map<GetListUniversityResponse>(university);
        return mappedUniversity;
    }

    public async Task<IPaginate<GetListUniversityResponse>> GetListAsync(PageRequest pageRequest)
    {
        var University = await _universityDal.GetListAsync(
        index: pageRequest.PageIndex,
        size: pageRequest.PageSize);
        var mappedUniversity = _mapper.Map<Paginate<GetListUniversityResponse>>(University);
        return mappedUniversity;
    }

    public async Task<UpdatedUniversityResponse> UpdateAsync(UpdateUniversityRequest updateUniversityRequest)
    {
        await _universityBusinessRules.IsExistsUniversity(updateUniversityRequest.Id);
        University university = _mapper.Map<University>(updateUniversityRequest);
        University updatedUniversity = await _universityDal.UpdateAsync(university);
        UpdatedUniversityResponse updatedUniversityResponse = _mapper.Map<UpdatedUniversityResponse>(updatedUniversity);
        return updatedUniversityResponse;
    }
}