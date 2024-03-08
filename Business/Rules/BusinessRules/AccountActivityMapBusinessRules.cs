using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules
{
    public class AccountActivityMapBusinessRules : BaseBusinessRules
    {
        private readonly IAccountActivityMapDal _accountActivityMapDal;

        public AccountActivityMapBusinessRules(IAccountActivityMapDal accountActivityMapDal)
        {
            _accountActivityMapDal = accountActivityMapDal;
        }

        public async Task IsExistsAccountActivityMap(Guid accountActivityMapId)
        {
            var result = await _accountActivityMapDal.GetAsync(
                predicate: aam => aam.Id == accountActivityMapId,
                enableTracking: false
                );
            if (result == null)
            {
                throw new BusinessException(BusinessMessages.DataNotFound);
            }
        }
    }
}
