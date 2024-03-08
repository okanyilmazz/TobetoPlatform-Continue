using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class BadgeBusinessRules : BaseBusinessRules
{
    private readonly IBadgeDal _badgeDal;

    public BadgeBusinessRules(IBadgeDal badgeDal)
    {
        _badgeDal = badgeDal;
    }

    public async Task IsExistsBadge(Guid badgeId)
    {
        var result = await _badgeDal.GetAsync(
            predicate: ab => ab.Id == badgeId,
            enableTracking: false
            );
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}