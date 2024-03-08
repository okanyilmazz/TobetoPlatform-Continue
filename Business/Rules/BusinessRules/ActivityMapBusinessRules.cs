using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules
{
	public class ActivityMapBusinessRules:BaseBusinessRules
	{
        private readonly IActivityMapDal _activityMapDal;

        public ActivityMapBusinessRules(IActivityMapDal activityMapDal)
        {
            _activityMapDal = activityMapDal;
        }

        public async Task IsExistsActivityMap(Guid activityMapId)
        {
            var result = await _activityMapDal.GetAsync(
                predicate: a => a.Id == activityMapId,
                enableTracking: false);

            if (result == null)
            {
                throw new BusinessException(BusinessMessages.DataNotFound);
            }
        }
    }
}

