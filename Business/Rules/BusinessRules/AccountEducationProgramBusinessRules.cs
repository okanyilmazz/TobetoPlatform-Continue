using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountEducationProgramBusinessRules : BaseBusinessRules
{
    private readonly IAccountEducationProgramDal _accountEducationProgramDal;

    public AccountEducationProgramBusinessRules(IAccountEducationProgramDal accountEducationProgramDal)
    {
        _accountEducationProgramDal = accountEducationProgramDal;
    }

    public async Task IsExistsAccountEducationProgram(Guid accountEducationProgramId)
    {
        var result = await _accountEducationProgramDal.GetAsync(
            predicate: q => q.Id == accountEducationProgramId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
