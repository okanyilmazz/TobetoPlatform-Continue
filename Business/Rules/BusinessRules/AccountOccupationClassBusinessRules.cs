using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountOccupationClassBusinessRules : BaseBusinessRules
{
    IAccountOccupationClassDal _accountOccupationClassDal;

    public AccountOccupationClassBusinessRules(IAccountOccupationClassDal accountOccupationClassDal)
    {
        _accountOccupationClassDal = accountOccupationClassDal;
    }

    public async Task IsExistsAccountOccupationClass(Guid accountOccupationClassId)
    {
        var result = await _accountOccupationClassDal.GetAsync(
            predicate: aoc => aoc.Id == accountOccupationClassId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
