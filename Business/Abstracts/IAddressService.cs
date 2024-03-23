using Business.Dtos.Requests.AddressRequests;
using Business.Dtos.Responses.AddressResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IAddressService
{
    Task<CreatedAddressResponse> AddAsync(CreateAddressRequest createAddressRequest);
    Task<UpdatedAddressResponse> UpdateAsync(UpdateAddressRequest updateAddressRequest);
    Task<DeletedAddressResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListAddressResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetAddressResponse> GetByIdAsync(Guid Id);
    Task<GetAddressResponse> GetByAccountIdAsync(Guid accountId);
}
