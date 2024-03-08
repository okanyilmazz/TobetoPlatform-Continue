using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramProgrammingLanguageBusinessRules : BaseBusinessRules
{
    private readonly IEducationProgramProgrammingLanguageDal _educationProgramProgrammingLanguageDal;

    public EducationProgramProgrammingLanguageBusinessRules(IEducationProgramProgrammingLanguageDal educationProgramProgrammingLanguageDal)
    {
        _educationProgramProgrammingLanguageDal = educationProgramProgrammingLanguageDal;
    }
    public async Task IsExistsEducationProgramProgrammingLanguage(Guid educationProgramProgrammingLanguageId)
    {
        var result = await _educationProgramProgrammingLanguageDal.GetAsync(
            predicate: e => e.Id == educationProgramProgrammingLanguageId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
