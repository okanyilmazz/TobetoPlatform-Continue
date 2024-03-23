using Business.Dtos.Requests.DegreeTypeRequests;
using Business.Dtos.Responses.DegreeTypeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IDegreeTypeService
{
    Task<CreatedDegreeTypeResponse> AddAsync(CreateDegreeTypeRequest creatDegreeTypeRequest);
    Task<DeletedDegreeTypeResponse> DeleteAsync(Guid id);
    Task<UpdatedDegreeTypeResponse> UpdateAsync(UpdateDegreeTypeRequest updateDegreeTypeRequest);
    Task<IPaginate<GetListDegreeTypeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetDegreeTypeResponse> GetByIdAsync(Guid id);
}
