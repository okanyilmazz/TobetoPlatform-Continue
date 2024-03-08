using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class UniversityDepartmentBusinessRules : BaseBusinessRules
{
    private readonly IUniversityDepartmentDal _universityDepartmentDal;

    public UniversityDepartmentBusinessRules(IUniversityDepartmentDal universityDepartmentDal)
    {
        _universityDepartmentDal = universityDepartmentDal;
    }

    public async Task IsExistsUniversityDepartment(Guid universityDepartmentId)
    {
        var result = await _universityDepartmentDal.GetAsync(
            predicate: ud => ud.Id == universityDepartmentId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
