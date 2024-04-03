using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class MediaNewImageBusinessRules : BaseBusinessRules
{
    private readonly IMediaNewImageDal _mediaNewImageDal;

    public MediaNewImageBusinessRules(IMediaNewImageDal mediaNewImageDal)
    {
        _mediaNewImageDal = mediaNewImageDal;
    }

    public async Task IsExistsMediaNewImage(Guid mediaNewImageId)
    {
        var result = await _mediaNewImageDal.GetAsync(
            predicate: b => b.Id == mediaNewImageId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
