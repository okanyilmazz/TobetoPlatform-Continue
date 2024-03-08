using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountUniversityBusinessRules : BaseBusinessRules
{
    private readonly IAccountUniversityDal _accountUniversityDal;

    public AccountUniversityBusinessRules(IAccountUniversityDal accountUniversityDal)
    {
        _accountUniversityDal = accountUniversityDal;
    }
    public async Task IsExistsAccountUniversity(Guid accountUniversityId)
    {
        var result = await _accountUniversityDal.GetListAsync(
            predicate: a => a.Id == accountUniversityId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
