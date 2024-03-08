using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramLikeBusinessRules : BaseBusinessRules
{
    IEducationProgramLikeDal _educationProgramLikeDal;

    public EducationProgramLikeBusinessRules(IEducationProgramLikeDal educationProgramLikeDal)
    {
        _educationProgramLikeDal = educationProgramLikeDal;
    }

    public async Task IsExistsEducationProgramLike(Guid id)
    {
        var result = await _educationProgramLikeDal.GetAsync(
            predicate: epl => epl.Id == id,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
    public async Task IsExistsEducationProgramLikeByAccountIdAndEducationProgramId(Guid accountId, Guid educationProgramId)
    {
        var result = await _educationProgramLikeDal.GetAsync(
            predicate: l => l.AccountId == accountId && l.EducationProgramId == educationProgramId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
