using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProjectBusinessRules : BaseBusinessRules
{
    IProjectDal _projectDal;

    public ProjectBusinessRules(IProjectDal projectDal)
    {
        _projectDal = projectDal;
    }

    public async Task IsExistsProject(Guid projectId)
    {
        var result = await _projectDal.GetAsync(
            predicate: a => a.Id == projectId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
