using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CompetenceResultBusinessRules : BaseBusinessRules
{
    private readonly ICompetenceResultDal _competenceResult;

    public CompetenceResultBusinessRules(ICompetenceResultDal competenceResult)
    {
        _competenceResult = competenceResult;
    }
    public async Task IsExistsCompetence(Guid competenceResultId)
    {
        var result = await _competenceResult.GetAsync(
             predicate: c => c.Id == competenceResultId,
        enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
