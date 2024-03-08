using Business.Dtos.Requests.CertificateRequests;
using Business.Dtos.Responses.CertificateResponses;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;

namespace Business.Abstracts;

public interface ICertificateService
{
    Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest, string currentPath);
    Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest);
    Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest);
    Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCertificateResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListCertificateResponse>> GetByAccountIdAsync(Guid accountId);
}
