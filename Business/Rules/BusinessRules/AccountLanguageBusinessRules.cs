using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountLanguageBusinessRules : BaseBusinessRules
{
    IAccountLanguageDal _accountLanguageDal;

    public AccountLanguageBusinessRules(IAccountLanguageDal accountLanguageDal)
    {
        _accountLanguageDal = accountLanguageDal;
    }

    public async Task IsExistsAccountLanguage(Guid accountLanguageId)
    {
        var result = await _accountLanguageDal.GetAsync(
            predicate: a => a.Id == accountLanguageId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
