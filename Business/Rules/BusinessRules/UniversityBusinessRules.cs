using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class UniversityBusinessRules : BaseBusinessRules
{
    private readonly IUniversityDal _universityDal;

    public UniversityBusinessRules(IUniversityDal universityDal)
    {
        _universityDal = universityDal;
    }

    public async Task IsExistsUniversity(Guid universityId)
    {
        var result = await _universityDal.GetAsync(
            predicate: u => u.Id == universityId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
