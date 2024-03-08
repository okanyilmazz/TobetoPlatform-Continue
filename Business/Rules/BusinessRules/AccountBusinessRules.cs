using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountBusinessRules : BaseBusinessRules
{
    IAccountDal _accountDal;

    public AccountBusinessRules(IAccountDal accountDal)
    {
        _accountDal = accountDal;
    }

    public async Task IsExistsAccount(Guid accountId)
    {
        var result = await _accountDal.GetAsync(
            predicate: a => a.Id == accountId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

    public async Task IsExistsNationalId(string nationalId)
    {
        if (nationalId != null)
        {
            var result = await _accountDal.GetAsync(
                predicate: a => a.NationalId == nationalId,
                enableTracking: false);
            if (result != null)
            {
                throw new BusinessException(BusinessMessages.DataAvailable);
            }
        }


    }

    public async Task IsExistsPhoneNumber(string phoneNumber)
    {
        if (phoneNumber != null)
        {
            var result = await _accountDal.GetAsync(
            predicate: a => a.PhoneNumber == phoneNumber,
            enableTracking: false);

            if (result != null)
            {
                throw new BusinessException(BusinessMessages.DataAvailable);
            }
        }
    }
}