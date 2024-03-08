using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramSubjectBusinessRules :BaseBusinessRules
{

    IEducationProgramSubjectDal _educationProgramSubjectDal;

    public EducationProgramSubjectBusinessRules(IEducationProgramSubjectDal educationProgramSubjectDal)
    {
        _educationProgramSubjectDal = educationProgramSubjectDal;
    }

    public async Task IsExistsEducationProgramSubject(Guid educationProgramSubjectId)
    {
        var result = await _educationProgramSubjectDal.GetAsync(
            predicate: a => a.Id == educationProgramSubjectId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}