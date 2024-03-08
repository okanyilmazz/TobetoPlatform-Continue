using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProgrammingLanguageBusinessRules : BaseBusinessRules
{
    private readonly IProgrammingLanguageDal _programmingLanguageDal;

    public ProgrammingLanguageBusinessRules(IProgrammingLanguageDal programmingLanguageDal)
    {
        _programmingLanguageDal = programmingLanguageDal;
    }

    public async Task IsExistsProgrammingLanguage(Guid programmingLanguageId)
    {
        var result = await _programmingLanguageDal.GetAsync(
            predicate: s => s.Id == programmingLanguageId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}

