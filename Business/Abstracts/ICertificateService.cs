using Business.Dtos.Requests.CertificateRequests;
using Business.Dtos.Responses.CertificateResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICertificateService
{
    Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest, string currentPath);
    Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest);
    Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest);
    Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetCertificateResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListCertificateResponse>> GetByAccountIdAsync(Guid accountId);
}
