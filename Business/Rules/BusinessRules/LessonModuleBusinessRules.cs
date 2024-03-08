using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LessonModuleBusinessRules : BaseBusinessRules
{
    ILessonModuleDal _lessonModuleDal;

    public LessonModuleBusinessRules(ILessonModuleDal lessonModuleDal)
    {
        _lessonModuleDal = lessonModuleDal;
    }

    public async Task IsExistsLessonModule(Guid lessonModuleId)
    {
        var result = await _lessonModuleDal.GetAsync(
            predicate: l => l.Id == lessonModuleId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
