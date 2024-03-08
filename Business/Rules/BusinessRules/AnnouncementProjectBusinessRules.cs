using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AnnouncementProjectBusinessRules : BaseBusinessRules
{
    private readonly IAnnouncementProjectDal _announcementProjectDal;

    public AnnouncementProjectBusinessRules(IAnnouncementProjectDal announcementProjectDal)
    {
        _announcementProjectDal = announcementProjectDal;
    }

    public async Task IsExistsAnnouncementProject(Guid announcementProjectId)
    {
        var result = await _announcementProjectDal.GetAsync(
            predicate: a => a.Id == announcementProjectId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
