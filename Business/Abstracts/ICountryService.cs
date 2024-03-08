using System;
using Business.Dtos.Requests.CountryRequests;
using Business.Dtos.Responses.CountryResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ICountryService
{
    Task<CreatedCountryResponse> AddAsync(CreateCountryRequest createCountryRequest);
    Task<UpdatedCountryResponse> UpdateAsync(UpdateCountryRequest updateCountryRequest);
    Task<DeletedCountryResponse> DeleteAsync(DeleteCountryRequest deleteCountryRequest);
    Task<IPaginate<GetListCountryResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListCountryResponse> GetByIdAsync(Guid id);
}
