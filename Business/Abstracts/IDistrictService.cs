using Business.Dtos.Requests.DistrictRequests;
using Business.Dtos.Responses.DistrictResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IDistrictService
{
    Task<CreatedDistrictResponse> AddAsync(CreateDistrictRequest createDistrictRequest);
    Task<DeletedDistrictResponse> DeleteAsync(DeleteDistrictRequest deleteDistrictRequest);
    Task<UpdatedDistrictResponse> UpdateAsync(UpdateDistrictRequest updateDistrictRequest);
    Task<IPaginate<GetListDistrictResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetDistrictResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListDistrictResponse>> GetByCityIdAsync(Guid cityId);
}
