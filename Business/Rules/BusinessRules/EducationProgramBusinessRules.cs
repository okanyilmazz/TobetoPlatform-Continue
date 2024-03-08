using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramBusinessRules : BaseBusinessRules
{
    IEducationProgramDal _educationProgramDal;

    public EducationProgramBusinessRules(IEducationProgramDal educationProgramDal)
    {
        _educationProgramDal = educationProgramDal;
    }

    public async Task IsExistsEducationProgram(Guid educationProgramId)
    {
        var result = await _educationProgramDal.GetAsync(
        predicate: ep => ep.Id == educationProgramId,
        enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

}
