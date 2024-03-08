using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ManagementProgramBusinessRules: BaseBusinessRules
{
    private readonly IManagementProgramDal _managementProgramDal;

    public ManagementProgramBusinessRules(IManagementProgramDal managementProgramDal)
    {
        _managementProgramDal = managementProgramDal;
    }

    public async Task IsExistsManagementProgram(Guid id)
    {
        var result = await _managementProgramDal.GetAsync(
           predicate: d => d.Id == id,
           enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }

}
