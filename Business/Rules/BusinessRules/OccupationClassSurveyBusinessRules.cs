using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class OccupationClassSurveyBusinessRules : BaseBusinessRules
{
    private readonly IOccupationClassSurveyDal _occupationClassSurveyDal;

    public OccupationClassSurveyBusinessRules(IOccupationClassSurveyDal occupationClassSurveyDal)
    {
        _occupationClassSurveyDal = occupationClassSurveyDal;
    }

    public async Task IsExistsOccupationClassSurvey(Guid occupationClassSurveyId)
    {
        var result = await _occupationClassSurveyDal.GetAsync(
            predicate: o => o.Id == occupationClassSurveyId,
            enableTracking: false);
       
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}