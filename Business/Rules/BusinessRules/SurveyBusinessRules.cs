using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class SurveyBusinessRules : BaseBusinessRules
{
    private readonly ISurveyDal _surveyDal;

    public SurveyBusinessRules(ISurveyDal surveyDal)
    {
        _surveyDal = surveyDal;
    }
    public async Task IsExistsSurvey(Guid surveyId)
    {
        var result = await _surveyDal.GetAsync(
            predicate: s => s.Id == surveyId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}