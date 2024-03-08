using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class SubjectBusinessRules : BaseBusinessRules
{
    private readonly ISubjectDal _subjectDal;

    public SubjectBusinessRules(ISubjectDal subjectDal)
    {
        _subjectDal = subjectDal;
    }
    public async Task IsExistSubject(Guid subjectId)
    {
        var result = await _subjectDal.GetAsync(
            predicate: l => l.Id == subjectId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}