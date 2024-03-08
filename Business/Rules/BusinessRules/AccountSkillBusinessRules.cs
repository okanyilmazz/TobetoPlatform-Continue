using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountSkillBusinessRules : BaseBusinessRules
{
    IAccountSkillDal _accountSkillDal;

    public AccountSkillBusinessRules(IAccountSkillDal accountSkillDal)
    {
        _accountSkillDal = accountSkillDal;
    }

    public async Task IsExistsAccountSkill(Guid accountSkillId)
    {
        var result = await _accountSkillDal.GetAsync(
            predicate: a => a.Id == accountSkillId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
