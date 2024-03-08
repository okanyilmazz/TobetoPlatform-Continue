using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class QuestionBusinessRules : BaseBusinessRules
{
    private readonly IQuestionDal _questionDal;

    public QuestionBusinessRules(IQuestionDal questionDal)
    {
        _questionDal = questionDal;
    }

    public async Task IsExistsQuestion(Guid questionId)
    {
        var result = await _questionDal.GetAsync(
            predicate: q => q.Id == questionId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
