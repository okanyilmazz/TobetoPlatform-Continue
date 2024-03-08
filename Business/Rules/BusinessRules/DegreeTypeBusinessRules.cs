using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class DegreeTypeBusinessRules : BaseBusinessRules
{
    private readonly IDegreeTypeDal _degreeTypeDal;

    public DegreeTypeBusinessRules(IDegreeTypeDal degreeTypeDal)
    {
        _degreeTypeDal = degreeTypeDal;
    }

    public async Task IsExistsDegreeType(Guid degreeTypeId)
    {
        var result = await _degreeTypeDal.GetAsync(
            predicate:d => d.Id == degreeTypeId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}