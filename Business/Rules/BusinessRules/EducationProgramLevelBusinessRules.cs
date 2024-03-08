using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramLevelBusinessRules : BaseBusinessRules
{
    private readonly IEducationProgramLevelDal _educationProgramLevelDal;

    public EducationProgramLevelBusinessRules(IEducationProgramLevelDal educationProgramLevelDal)
    {
        _educationProgramLevelDal = educationProgramLevelDal;
    }

    public async Task IsExistsEducationProgramLevel(Guid educationProgramLevelId)
    {
        var result = await _educationProgramLevelDal.GetAsync(
            predicate: q => q.Id == educationProgramLevelId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
