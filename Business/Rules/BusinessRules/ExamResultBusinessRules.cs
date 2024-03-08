using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ExamResultBusinessRules : BaseBusinessRules
{
    IExamResultDal _examResultDal;

    public ExamResultBusinessRules(IExamResultDal examResultDal)
    {
        _examResultDal = examResultDal;
    }

    public async Task IsExistsExamResult(Guid examResultId)
    {
        var result = await _examResultDal.GetAsync(
            predicate: e => e.Id == examResultId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
