using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class QuestionTypeBusinessRules : BaseBusinessRules
{
    private readonly IQuestionTypeDal _questionTypeDal;

    public QuestionTypeBusinessRules(IQuestionTypeDal questionTypeDal)
    {
        _questionTypeDal = questionTypeDal;
    }

    public async Task IsExistsQuestionType(Guid questionTypeId)
    {
        var result = await _questionTypeDal.GetAsync(
            predicate: q => q.Id == questionTypeId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}