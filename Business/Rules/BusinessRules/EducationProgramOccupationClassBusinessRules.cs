using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramOccupationClassBusinessRules : BaseBusinessRules
{
    private readonly IEducationProgramOccupationClassDal _educationProgramOccupationClassDal;

    public EducationProgramOccupationClassBusinessRules(IEducationProgramOccupationClassDal educationProgramOccupationClassDal)
    {
        _educationProgramOccupationClassDal = educationProgramOccupationClassDal;
    }

    public async Task IsExistsEducationProgramOccupationClass(Guid educationProgramOccupationClassId)
    {
        var result = await _educationProgramOccupationClassDal.GetAsync(
            predicate: e => e.Id == educationProgramOccupationClassId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}

