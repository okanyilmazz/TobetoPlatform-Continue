using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class OccupationBusinessRules : BaseBusinessRules
{
    private readonly IOccupationDal _occupationDal;

    public OccupationBusinessRules(IOccupationDal occupationDal)
    {
        _occupationDal = occupationDal;
    }

    public async Task IsExistsOccupation(Guid occupationId)
    {
        var result = await _occupationDal.GetAsync(
            predicate: q => q.Id == occupationId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
