using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CompetenceCategoryBusinessRules : BaseBusinessRules
{
    private readonly ICompetenceCategoryDal _competenceCategoryDal;

    public CompetenceCategoryBusinessRules(ICompetenceCategoryDal competenceCategoryDal)
    {
        _competenceCategoryDal = competenceCategoryDal;
    }

    public async Task IsExistsCompetence(Guid competenceCategoryId)
    {
        var result = await _competenceCategoryDal.GetAsync(
             predicate: c => c.Id == competenceCategoryId,
        enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}