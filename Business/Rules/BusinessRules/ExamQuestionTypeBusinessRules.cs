using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ExamQuestionTypeBusinessRules : BaseBusinessRules
{
    IExamQuestionTypeDal _examQuestionTypeDal;

    public ExamQuestionTypeBusinessRules(IExamQuestionTypeDal examQuestionTypeDal)
    {
        _examQuestionTypeDal = examQuestionTypeDal;
    }

    public async Task IsExistsExamQuestionType(Guid examQuestionTypeId)
    {
        var result = await _examQuestionTypeDal.GetAsync(
            predicate: e => e.Id == examQuestionTypeId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
