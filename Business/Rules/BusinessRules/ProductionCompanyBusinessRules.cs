using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProductionCompanyBusinessRules : BaseBusinessRules
{
    IProductionCompanyDal _productionCompanyDal;

    public ProductionCompanyBusinessRules(IProductionCompanyDal productionCompanyDal)
    {
        _productionCompanyDal = productionCompanyDal;
    }

    public async Task IsExistsProductionCompany(Guid productionCompanyId)
    {
        var result = await _productionCompanyDal.GetAsync(
            predicate: p => p.Id == productionCompanyId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
