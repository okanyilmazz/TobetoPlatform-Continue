using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LessonCategoryBusinessRules : BaseBusinessRules
{

    ILessonCategoryDal _lessonCategoryDal;

    public LessonCategoryBusinessRules(ILessonCategoryDal lessonCategoryDal)
    {
        _lessonCategoryDal = lessonCategoryDal;
    }

    public async Task IsExistsLessonCategory(Guid lessonCategoryId)
    {
        var result = await _lessonCategoryDal.GetAsync(
            predicate: l => l.Id == lessonCategoryId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}

