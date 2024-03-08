using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountCompetenceTestBusinessRules : BaseBusinessRules
{
    private readonly IAccountCompetenceTestDal _accountCompetenceTestDal;

    public AccountCompetenceTestBusinessRules(IAccountCompetenceTestDal accountCompetenceTestDal)
    {
        _accountCompetenceTestDal = accountCompetenceTestDal;
    }

    public async Task IsExistsAccountCompetenceTest(Guid accountCompetenceTestId)
    {
        var result = await _accountCompetenceTestDal.GetAsync(
            predicate: ab => ab.Id == accountCompetenceTestId,
            enableTracking: false
            );
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
