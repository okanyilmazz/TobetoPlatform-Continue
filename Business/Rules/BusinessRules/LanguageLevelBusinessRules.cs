using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LanguageLevelBusinessRules : BaseBusinessRules
{
    private readonly ILanguageLevelDal _languageLevelDal;

    public LanguageLevelBusinessRules(ILanguageLevelDal languageLevelDal)
    {
        _languageLevelDal = languageLevelDal;
    }

    public async Task IsExistsLanguageLevel(Guid languageLevelId)
    {
        var result = await _languageLevelDal.GetAsync(
            predicate: l => l.Id == languageLevelId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
