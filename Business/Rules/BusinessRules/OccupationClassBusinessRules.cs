using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class OccupationClassBusinessRules : BaseBusinessRules
{
    IOccupationClassDal _occupationClassDal;

    public OccupationClassBusinessRules(IOccupationClassDal occupationClassDal)
    {
        _occupationClassDal = occupationClassDal;
    }

    public async Task IsExistsOccupationClass(Guid occupationClassId)
    {
        var result = await _occupationClassDal.GetAsync(
            predicate: a => a.Id == occupationClassId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
    public async Task IsExistUser(Guid accountId)
    {
        var result = await _occupationClassDal.GetAsync(
            predicate: a => a.AccountOccupationClasses.Any(aoc => aoc.AccountId == accountId),
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.NotAssignedToOccupationClass);
        }
    }
}
