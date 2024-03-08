using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountHomeworkBusinessRules : BaseBusinessRules
{
    private readonly IAccountHomeworkDal _accountHomeworkDal;

    public AccountHomeworkBusinessRules(IAccountHomeworkDal accountHomeworkDal)
    {
        _accountHomeworkDal = accountHomeworkDal;
    }

    public async Task IsExistsAccountHomework(Guid accountHomeworkId)
    {
        var result = await _accountHomeworkDal.GetAsync(
            predicate: a => a.Id == accountHomeworkId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
