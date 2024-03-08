using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AccountAnswerBusinessRules : BaseBusinessRules
{
    private readonly IAccountAnswerDal _accountAnswerDal;

    public AccountAnswerBusinessRules(IAccountAnswerDal accountAnswerDal)
    {
        _accountAnswerDal = accountAnswerDal;
    }

    public async Task IsExistsAccountAnswer(Guid accountAnswerId)
    {
        var result = await _accountAnswerDal.GetAsync(
            predicate: q => q.Id == accountAnswerId,
            enableTracking: false
            );
        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}