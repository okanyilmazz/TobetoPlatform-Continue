using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ExamOccupationClassBusinessRules : BaseBusinessRules
{
    private readonly IExamOccupationClassDal _examOccupationClassDal;

    public ExamOccupationClassBusinessRules(IExamOccupationClassDal examOccupationClassDal)
    {
        _examOccupationClassDal = examOccupationClassDal;
    }

    public async Task IsExistsExamOccupationClass(Guid examOccupationClassId)
    {
        var result = await _examOccupationClassDal.GetAsync(
            predicate: e => e.Id == examOccupationClassId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
