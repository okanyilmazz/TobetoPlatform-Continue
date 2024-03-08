using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class HomeworkBusinessRules : BaseBusinessRules
{
    IHomeworkDal _homeworkDal;

    public HomeworkBusinessRules(IHomeworkDal homeworkDal)
    {
        _homeworkDal = homeworkDal;
    }

    public async Task IsExistsHomework(Guid homeworkId)
    {
        var result = await _homeworkDal.GetAsync(
            predicate: h => h.Id == homeworkId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
