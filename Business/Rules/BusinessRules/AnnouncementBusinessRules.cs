using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AnnouncementBusinessRules : BaseBusinessRules
{
    IAnnouncementDal _announcementDal;

    public AnnouncementBusinessRules(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }

    public async Task IsExistsAnnouncement(Guid announcementId)
    {
        var result = await _announcementDal.GetAsync(
            predicate: a => a.Id == announcementId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
