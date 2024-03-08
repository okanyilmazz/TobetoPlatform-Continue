using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class WorkExperienceBusinessRules : BaseBusinessRules
{
    IWorkExperienceDal _workExperienceDal;

    public WorkExperienceBusinessRules(IWorkExperienceDal workExperienceDal)
    {
        _workExperienceDal = workExperienceDal;
    }

    public async Task IsExistsWorkExperience(Guid workExperienceId)
    {
        var result = await _workExperienceDal.GetAsync(
            predicate: s => s.Id == workExperienceId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
    