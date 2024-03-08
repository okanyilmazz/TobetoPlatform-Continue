using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.LanguageLevelRequests;
using Business.Dtos.Responses.LanguageLevelResponses;
using Business.Rules.BusinessRules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes;

public class LanguageLevelManager : ILanguageLevelService
{
    ILanguageLevelDal _languageLevelDal;
    IMapper _mapper;
    LanguageLevelBusinessRules _languageLevelBusinessRules;

    public LanguageLevelManager(ILanguageLevelDal languageLevelDal, IMapper mapper, LanguageLevelBusinessRules languageLevelBusinessRules)
    {
        _languageLevelDal = languageLevelDal;
        _mapper = mapper;
        _languageLevelBusinessRules = languageLevelBusinessRules;
    }

    public async Task<CreatedLanguageLevelResponse> AddAsync(CreateLanguageLevelRequest createLanguageLevelRequest)
    {
        LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(createLanguageLevelRequest);
        LanguageLevel addedLanguageLevel = await _languageLevelDal.AddAsync(languageLevel);
        CreatedLanguageLevelResponse responseLanguageLevel = _mapper.Map<CreatedLanguageLevelResponse>(addedLanguageLevel);
        return responseLanguageLevel;

    }
    public async Task<UpdatedLanguageLevelResponse> UpdateAsync(UpdateLanguageLevelRequest updateLanguageLevelRequest)
    {
        await _languageLevelBusinessRules.IsExistsLanguageLevel(updateLanguageLevelRequest.Id);
        LanguageLevel languageLevel = _mapper.Map<LanguageLevel>(updateLanguageLevelRequest);
        LanguageLevel updatedLanguageLevel = await _languageLevelDal.UpdateAsync(languageLevel);
        UpdatedLanguageLevelResponse responseLanguageLevel = _mapper.Map<UpdatedLanguageLevelResponse>(updatedLanguageLevel);
        return responseLanguageLevel;
    }

    public async Task<DeletedLanguageLevelResponse> DeleteAsync(DeleteLanguageLevelRequest deleteLanguageLevelRequest)
    {
        await _languageLevelBusinessRules.IsExistsLanguageLevel(deleteLanguageLevelRequest.Id);
        LanguageLevel languageLevel = await _languageLevelDal.GetAsync(predicate: l => l.Id == deleteLanguageLevelRequest.Id);
        LanguageLevel deletedLanguageLevel = await _languageLevelDal.DeleteAsync(languageLevel);
        DeletedLanguageLevelResponse deletedLanguageLevelResponse = _mapper.Map<DeletedLanguageLevelResponse>(deletedLanguageLevel);
        return deletedLanguageLevelResponse;
    }

    public async Task<IPaginate<GetListLanguageLevelResponse>> GetListAsync(PageRequest pageRequest)
    {
        var languageLevelListed = await _languageLevelDal.GetListAsync(
            index: pageRequest.PageIndex,
            size: pageRequest.PageSize);
        var mappedListed = _mapper.Map<Paginate<GetListLanguageLevelResponse>>(languageLevelListed);
        return mappedListed;
    }

    public async Task<GetListLanguageLevelResponse> GetByIdAsync(Guid id)
    {
        var languageLevel = await _languageLevelDal.GetListAsync(l => l.Id == id);
        return _mapper.Map<GetListLanguageLevelResponse>(languageLevel.Items.FirstOrDefault());
    }
}
