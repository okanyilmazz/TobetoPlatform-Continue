using Business.Dtos.Requests.CityRequests;
using Business.Dtos.Responses.CityResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICityService
    {
        Task<CreatedCityResponse> AddAsync(CreateCityRequest createCityRequest);
        Task<UpdatedCityResponse> UpdateAsync(UpdateCityRequest updateCityRequest);
        Task<DeletedCityResponse> DeleteAsync(DeleteCityRequest deleteCityRequest);
        Task<IPaginate<GetListCityResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListCityResponse> GetByIdAsync(Guid id);
    }
}
