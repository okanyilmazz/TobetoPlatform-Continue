using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class AddressBusinessRules : BaseBusinessRules
{
    private readonly IAddressDal _addressDal;

    public AddressBusinessRules(IAddressDal addressDal)
    {
        _addressDal = addressDal;
    }

    public async Task IsExistsAdress(Guid addressId)
    {
        var result = await _addressDal.GetAsync(
            predicate: a => a.Id == addressId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
