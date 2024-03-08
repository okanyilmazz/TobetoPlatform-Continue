using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LessonSubTypeBusinessRules : BaseBusinessRules
{

    private readonly ILessonSubTypeDal _lessonSubTypeDal;

    public LessonSubTypeBusinessRules(ILessonSubTypeDal lessonSubTypeDal)
    {
        _lessonSubTypeDal = lessonSubTypeDal;
    }

    public async Task IsExistsLessonSubType(Guid lessonSubTypeId)
    {
        var result = await _lessonSubTypeDal.GetAsync(
           predicate: l => l.Id == lessonSubTypeId,
           enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
