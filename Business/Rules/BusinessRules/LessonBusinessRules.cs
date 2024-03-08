using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LessonBusinessRules : BaseBusinessRules
{
    ILessonDal _lessonDal;

    public LessonBusinessRules(ILessonDal lessonDal)
    {
        _lessonDal = lessonDal;
    }

    public async Task IsExistsLesson(Guid lessonId)
    {
        var result = await _lessonDal.GetAsync(
            predicate: l => l.Id == lessonId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }

    }
      
}
