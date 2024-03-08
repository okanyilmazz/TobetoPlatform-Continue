using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CountryBusinessRules : BaseBusinessRules
{
    private readonly ICountryDal _countryDal;

    public CountryBusinessRules(ICountryDal countryDal)
    {
        _countryDal = countryDal;
    }

    public async Task IsExistsCountry(Guid countryId)
    {
        var result = await _countryDal.GetAsync(
            predicate: c => c.Id == countryId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    } 
}
