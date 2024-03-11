using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountFavoriteEducationProgramBusinessRules : BaseBusinessRules
{
    private readonly IAccountFavoriteEducationProgramDal _accountFavoriteEducationProgramDal;

    public AccountFavoriteEducationProgramBusinessRules(IAccountFavoriteEducationProgramDal accountFavoriteEducationProgramDal)
    {
        _accountFavoriteEducationProgramDal = accountFavoriteEducationProgramDal;
    }
    public async Task IsExistsAccountFavoriteEducationProgram(Guid accountFavoriteEducationProgramId)
    {
        var result = await _accountFavoriteEducationProgramDal.GetAsync(
            predicate: a => a.Id == accountFavoriteEducationProgramId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
