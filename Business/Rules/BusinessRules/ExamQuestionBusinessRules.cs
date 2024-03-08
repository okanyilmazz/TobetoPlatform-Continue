using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ExamQuestionBusinessRules : BaseBusinessRules
{
    IExamQuestionDal _examQuestionDal;

    public ExamQuestionBusinessRules(IExamQuestionDal examQuestionDal)
    {
        _examQuestionDal = examQuestionDal;
    }

    public async Task IsExistsExamQuestion(Guid examQuestionId)
    {
        var result = await _examQuestionDal.GetAsync(
            predicate: eq => eq.Id == examQuestionId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
