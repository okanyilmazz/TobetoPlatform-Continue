using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AnnouncementTypeBusinessRules : BaseBusinessRules
{
    private readonly IAnnouncementTypeDal _announcementTypeDal;

    public AnnouncementTypeBusinessRules(IAnnouncementTypeDal announcementTypeDal)
    {
        _announcementTypeDal = announcementTypeDal;
    }
    public async Task IsExistsAnnouncementType(Guid announcementTypeId)
    {
        var result = await _announcementTypeDal.GetAsync(
            predicate: at => at.Id == announcementTypeId,
            enableTracking: false
            );
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
