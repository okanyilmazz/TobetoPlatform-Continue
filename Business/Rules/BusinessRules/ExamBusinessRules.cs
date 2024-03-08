using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ExamBusinessRules : BaseBusinessRules
{
    private readonly IExamDal _examDal;

    public ExamBusinessRules(IExamDal examDal)
    {
        _examDal = examDal;
    }

    public async Task IsExistsExam(Guid examId)
    {
        var result = await _examDal.GetAsync(
            predicate: c => c.Id == examId, 
            enableTracking: false);

        if (result==null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
