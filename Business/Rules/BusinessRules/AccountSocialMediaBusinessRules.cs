using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountSocialMediaBusinessRules : BaseBusinessRules
{
    IAccountSocialMediaDal _accountSocialMediaDal;

    public AccountSocialMediaBusinessRules(IAccountSocialMediaDal accountSocialMediaDal)
    {
        _accountSocialMediaDal = accountSocialMediaDal;
    }

    public async Task IsExistsAccountSocialMedia(Guid accountSocialMediaId)
    {
        var result = await _accountSocialMediaDal.GetAsync(
            predicate: a => a.Id == accountSocialMediaId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
