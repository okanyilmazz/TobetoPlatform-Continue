using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.EducationProgramProgrammingLanguageRequests;
using Business.Dtos.Responses.EducationProgramProgrammingLanguageResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class EducationProgramProgrammingLanguageManager : IEducationProgramProgrammingLanguageService
{
    IEducationProgramProgrammingLanguageDal _educationProgramProgrammingLanguageDal;
    IMapper _mapper;
    EducationProgramProgrammingLanguageBusinessRules _educationProgramProgrammingLanguageBusinessRules;

    public EducationProgramProgrammingLanguageManager(IEducationProgramProgrammingLanguageDal educationProgramProgrammingLanguageDal, IMapper mapper, EducationProgramProgrammingLanguageBusinessRules educationProgramProgrammingLanguageBusinessRules)
    {
        _educationProgramProgrammingLanguageDal = educationProgramProgrammingLanguageDal;
        _mapper = mapper;
        _educationProgramProgrammingLanguageBusinessRules = educationProgramProgrammingLanguageBusinessRules;
    }

    public async Task<CreatedEducationProgramProgrammingLanguageResponse> AddAsync(CreateEducationProgramProgrammingLanguageRequest createEducationProgramProgrammingLanguageRequest)
    {
        EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(createEducationProgramProgrammingLanguageRequest);
        EducationProgramProgrammingLanguage addedEducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.AddAsync(educationProgramLanguageProgramming);
        CreatedEducationProgramProgrammingLanguageResponse createdEducationProgramProgrammingLanguageResponse = _mapper.Map<CreatedEducationProgramProgrammingLanguageResponse>(addedEducationProgramProgrammingLanguage);
        return createdEducationProgramProgrammingLanguageResponse;
    }

    public async Task<DeletedEducationProgramProgrammingLanguageResponse> DeleteAsync(Guid id)
    {
        await _educationProgramProgrammingLanguageBusinessRules.IsExistsEducationProgramProgrammingLanguage(id);
        EducationProgramProgrammingLanguage educationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.GetAsync(predicate: l => l.Id == id);
        EducationProgramProgrammingLanguage deletedEducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.DeleteAsync(educationProgramProgrammingLanguage);
        DeletedEducationProgramProgrammingLanguageResponse deletedEducationProgramProgrammingLanguageResponse = _mapper.Map<DeletedEducationProgramProgrammingLanguageResponse>(deletedEducationProgramProgrammingLanguage);
        return deletedEducationProgramProgrammingLanguageResponse;
    }

    public async Task<GetEducationProgramProgrammingLanguageResponse> GetByIdAsync(Guid id)
    {
        var EducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.GetAsync(
            predicate: p => p.Id == id,
            include: ep => ep
            .Include(ep => ep.EducationProgram)
            .Include(ep => ep.ProgrammingLanguage));
        var mappedEducationProgramProgrammingLanguage = _mapper.Map<GetEducationProgramProgrammingLanguageResponse>(EducationProgramProgrammingLanguage);
        return mappedEducationProgramProgrammingLanguage;
    }

    public async Task<IPaginate<GetListEducationProgramProgrammingLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var EducationProgramProgrammingLanguages = await _educationProgramProgrammingLanguageDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize,
            include: ep => ep
            .Include(ep => ep.EducationProgram)
            .Include(ep => ep.ProgrammingLanguage));
        var mappedEducationProgramProgrammingLanguages = _mapper.Map<Paginate<GetListEducationProgramProgrammingLanguageResponse>>(EducationProgramProgrammingLanguages);
        return mappedEducationProgramProgrammingLanguages;
    }

    public async Task<UpdatedEducationProgramProgrammingLanguageResponse> UpdateAsync(UpdateEducationProgramProgrammingLanguageRequest updateEducationProgramProgrammingLanguageRequest)
    {
        await _educationProgramProgrammingLanguageBusinessRules.IsExistsEducationProgramProgrammingLanguage(updateEducationProgramProgrammingLanguageRequest.Id);
        EducationProgramProgrammingLanguage educationProgramLanguageProgramming = _mapper.Map<EducationProgramProgrammingLanguage>(updateEducationProgramProgrammingLanguageRequest);
        EducationProgramProgrammingLanguage updatedEducationProgramProgrammingLanguage = await _educationProgramProgrammingLanguageDal.UpdateAsync(educationProgramLanguageProgramming);
        UpdatedEducationProgramProgrammingLanguageResponse updatedEducationProgramProgrammingLanguageResponse = _mapper.Map<UpdatedEducationProgramProgrammingLanguageResponse>(updatedEducationProgramProgrammingLanguage);
        return updatedEducationProgramProgrammingLanguageResponse;
    }
}
