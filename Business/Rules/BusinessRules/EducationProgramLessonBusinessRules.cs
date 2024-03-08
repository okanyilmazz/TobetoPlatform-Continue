using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramLessonBusinessRules : BaseBusinessRules
{
    IEducationProgramLessonDal _educationProgramLessonDal;

    public EducationProgramLessonBusinessRules(IEducationProgramLessonDal educationProgramLessonDal)
    {
        _educationProgramLessonDal = educationProgramLessonDal;
    }

    public async Task IsExistsEducationProgramLesson(Guid educationProgramLessonId)
    {
        var result = await _educationProgramLessonDal.GetAsync(
            predicate: a => a.Id == educationProgramLessonId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
