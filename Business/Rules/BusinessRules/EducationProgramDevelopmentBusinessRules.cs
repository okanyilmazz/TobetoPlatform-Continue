using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramDevelopmentBusinessRules : BaseBusinessRules
{
    IEducationProgramDevelopmentDal _educationProgramDevelopmentDal;

    public EducationProgramDevelopmentBusinessRules(IEducationProgramDevelopmentDal educationProgramDevelopmentDal)
    {
        _educationProgramDevelopmentDal = educationProgramDevelopmentDal;
    }
    public async Task IsExistsEducationProgramDevelopment(Guid educationProgramDevelopmentId)
    {
        var result = await _educationProgramDevelopmentDal.GetAsync(
            predicate: a => a.Id == educationProgramDevelopmentId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

}