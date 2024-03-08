using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CertificateBusinessRules:BaseBusinessRules
	{
    private readonly ICertificateDal _certificateDal;

    public CertificateBusinessRules(ICertificateDal certificateDal)
    {
        _certificateDal = certificateDal;
    }

    public async Task IsExistsCertificate(Guid certificateId)
    {
        var result = await _certificateDal.GetAsync(
            predicate: c => c.Id == certificateId, 
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}

