using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class SocialMediaBusinessRules : BaseBusinessRules
{
    private readonly ISocialMediaDal _socialMediaDal;

    public SocialMediaBusinessRules(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }

    public async Task IsExistsSocialMedia(Guid socialMediaId)
    {
        var result = await _socialMediaDal.GetAsync(
            predicate: s => s.Id == socialMediaId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
