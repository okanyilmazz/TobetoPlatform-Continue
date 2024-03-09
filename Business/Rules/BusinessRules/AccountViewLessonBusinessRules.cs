using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountViewLessonBusinessRules : BaseBusinessRules
{
    private readonly IAccountViewLessonDal _accountViewLessonDal;

    public AccountViewLessonBusinessRules(IAccountViewLessonDal accountViewLessonDal)
    {
        _accountViewLessonDal = accountViewLessonDal;
    }
    public async Task IsExistsAccountViewLesson(Guid accountViewLessonId)
    {
        var result = await _accountViewLessonDal.GetAsync(
            predicate: a => a.Id == accountViewLessonId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
