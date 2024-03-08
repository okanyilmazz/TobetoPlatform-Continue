using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.ProgrammingLanguageRequests;
using Business.Dtos.Responses.ProgrammingLanguageResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class ProgrammingLanguageManager : IProgrammingLanguageService
{
    IProgrammingLanguageDal _programmingLanguageDal;
    IMapper _mapper;
    ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

    public ProgrammingLanguageManager(IProgrammingLanguageDal programmingLanguageDal, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
    {
        _programmingLanguageDal = programmingLanguageDal;
        _mapper = mapper;
        _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
    }

    public async Task<CreatedProgrammingLanguageResponse> AddAsync(CreateProgrammingLanguageRequest createProgrammingLanguageRequest)
    {
        ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(createProgrammingLanguageRequest);
        ProgrammingLanguage addedProgrammingLanguage = await _programmingLanguageDal.AddAsync(programmingLanguage);
        CreatedProgrammingLanguageResponse createdProgrammingLanguageResponse = _mapper.Map<CreatedProgrammingLanguageResponse>(addedProgrammingLanguage);
        return createdProgrammingLanguageResponse;
    }

    public async Task<DeletedProgrammingLanguageResponse> DeleteAsync(DeleteProgrammingLanguageRequest deleteProgrammingLanguageRequest)
    {
        await _programmingLanguageBusinessRules.IsExistsProgrammingLanguage(deleteProgrammingLanguageRequest.Id);
        ProgrammingLanguage programmingLanguage = await _programmingLanguageDal.GetAsync(predicate: a => a.Id == deleteProgrammingLanguageRequest.Id);
        ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageDal.DeleteAsync(programmingLanguage);
        DeletedProgrammingLanguageResponse createdProgrammingLanguageResponse = _mapper.Map<DeletedProgrammingLanguageResponse>(deletedProgrammingLanguage);
        return createdProgrammingLanguageResponse;
    }

    public async Task<IPaginate<GetListProgrammingLanguageResponse>> GetListAsync(PageRequest pageRequest)
    {
        var programmingLanguages = await _programmingLanguageDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize
            );
        var mappedProgrammingLanguages = _mapper.Map<Paginate<GetListProgrammingLanguageResponse>>(programmingLanguages);
        return mappedProgrammingLanguages;
    }

    public async Task<GetListProgrammingLanguageResponse> GetByIdAsync(Guid id)
    {
        var programmingLanguage = await _programmingLanguageDal.GetAsync(p => p.Id == id);
        var mappedProgrammingLanguage = _mapper.Map<GetListProgrammingLanguageResponse>(programmingLanguage);
        return mappedProgrammingLanguage;
    }

    public async Task<UpdatedProgrammingLanguageResponse> UpdateAsync(UpdateProgrammingLanguageRequest updateProgrammingLanguageRequest)
    {
        await _programmingLanguageBusinessRules.IsExistsProgrammingLanguage(updateProgrammingLanguageRequest.Id);
        ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(updateProgrammingLanguageRequest);
        ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageDal.UpdateAsync(programmingLanguage);
        UpdatedProgrammingLanguageResponse updatedProgrammingLanguageResponse = _mapper.Map<UpdatedProgrammingLanguageResponse>(updatedProgrammingLanguage);
        return updatedProgrammingLanguageResponse;
    }
}
