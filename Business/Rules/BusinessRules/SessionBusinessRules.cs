using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class SessionBusinessRules : BaseBusinessRules
{
    private readonly ISessionDal _sessionDal;

    public SessionBusinessRules(ISessionDal sessionDal)
    {
        _sessionDal = sessionDal;
    }

    public async Task IsExistsSession(Guid sessionId)
    {
        var result = await _sessionDal.GetAsync(
            predicate: s => s.Id == sessionId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
