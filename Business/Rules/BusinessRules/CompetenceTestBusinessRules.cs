using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CompetenceTestBusinessRules : BaseBusinessRules
{
    private readonly ICompetenceTestDal _competenceTestDal;

    public CompetenceTestBusinessRules(ICompetenceTestDal competenceTestDal)
    {
        _competenceTestDal = competenceTestDal;
    }

    public async Task IsExistsCompetenceTest(Guid competenceTestId)
    {
        var result = await _competenceTestDal.GetAsync(
            predicate: ct => ct.Id == competenceTestId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
