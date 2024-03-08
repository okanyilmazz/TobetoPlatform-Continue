using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountBadgeBusinessRules : BaseBusinessRules
{
    private readonly IAccountBadgeDal _accountBadgeDal;

    public AccountBadgeBusinessRules(IAccountBadgeDal accountBadgeDal)
    {
        _accountBadgeDal = accountBadgeDal;
    }

    public async Task IsExistsAccountBadge(Guid accountBadgeId)
    {
        var result = await _accountBadgeDal.GetAsync(
            predicate: ab => ab.Id == accountBadgeId,
            enableTracking: false
            );
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}