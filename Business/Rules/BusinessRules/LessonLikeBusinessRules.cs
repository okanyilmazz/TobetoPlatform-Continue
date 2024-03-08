using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LessonLikeBusinessRules : BaseBusinessRules
{
    ILessonLikeDal _lessonLikeDal;

    public LessonLikeBusinessRules(ILessonLikeDal lessonLikeDal)
    {
        _lessonLikeDal = lessonLikeDal;
    }

    public async Task IsExistsLessonLike(Guid id)
    {
        var result = await _lessonLikeDal.GetAsync(
            predicate: l => l.Id == id,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

    public async Task IsExistsLessonLikeByAccountIdAndLessonId(Guid accountId, Guid lessonId)
    {
        var result = await _lessonLikeDal.GetAsync(
            predicate: l => l.AccountId == accountId && l.LessonId == lessonId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
