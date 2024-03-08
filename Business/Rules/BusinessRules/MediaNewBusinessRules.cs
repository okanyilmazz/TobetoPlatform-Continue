using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class MediaNewBusinessRules : BaseBusinessRules
{
    IMediaNewDal _mediaNewDal;

    public MediaNewBusinessRules(IMediaNewDal mediaNewDal)
    {
        _mediaNewDal = mediaNewDal;
    }

    public async Task IsExistsMediaNew(Guid mediaNewId)
    {
        var result = await _mediaNewDal.GetAsync(
            predicate: m => m.Id == mediaNewId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
