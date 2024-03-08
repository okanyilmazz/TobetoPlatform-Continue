using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ContactBusinessRules : BaseBusinessRules
{
    private readonly IContactDal _contactDal;

    public ContactBusinessRules(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }

    public async Task IsExistsContact(Guid contactId)
    {
        var result = await _contactDal.GetAsync(
            predicate: c => c.Id == contactId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
