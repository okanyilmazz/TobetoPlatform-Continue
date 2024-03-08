using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountLessonBusinessRules : BaseBusinessRules
{
    IAccountLessonDal _accountLessonDal;

    public AccountLessonBusinessRules(IAccountLessonDal AccountLessonDal)
    {
        _accountLessonDal = AccountLessonDal;
    }

    public async Task IsExistsAccountLesson(Guid accountLessonId)
    {
        var result = await _accountLessonDal.GetAsync(
            predicate: a => a.Id == accountLessonId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}