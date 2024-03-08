using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AnnouncementReadBusinessRules : BaseBusinessRules
{
    private readonly IAnnouncementReadDal _announcementReadDal;

    public AnnouncementReadBusinessRules(IAnnouncementReadDal announcementReadDal)
    {
        _announcementReadDal = announcementReadDal;
    }

    public async Task IsExistsAnnouncementRead(Guid announcementReadId)
    {
        var result = await _announcementReadDal.GetAsync(
            predicate: at => at.Id == announcementReadId,
            enableTracking: false
            );
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

    public async Task IsExistsAnnouncementReadByAccountIdAndAnnouncementId(Guid accountId, Guid announcementId)
    {
        var result = await _announcementReadDal.GetAsync(
            predicate: l => l.AccountId == accountId && l.AnnouncementId == announcementId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
