
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CompetenceQuestionBusinessRules : BaseBusinessRules
{
    private readonly ICompetenceQuestionDal _competenceQuestionDal;

    public CompetenceQuestionBusinessRules(ICompetenceQuestionDal competenceQuestionDal)
    {
        _competenceQuestionDal = competenceQuestionDal;
    }
    public async Task IsExistsCompetence(Guid competenceQuestionId)
    {
        var result = await _competenceQuestionDal.GetAsync(
             predicate: c => c.Id == competenceQuestionId,
        enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}