using Business.Dtos.Requests.ManagementProgramRequests;
using Business.Dtos.Responses.ManagementProgramResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IManagementProgramService
{
    Task<IPaginate<GetListManagementProgramResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedManagementProgramResponse> AddAsync(CreateManagementProgramRequest createManagementProgramRequest);
    Task<UpdatedManagementProgramResponse> UpdateAsync(UpdateManagementProgramRequest updateManagementProgramRequest);
    Task<DeletedManagementProgramResponse> DeleteAsync(DeleteManagementProgramRequest deleteManagementProgramRequest);
    Task<GetManagementProgramResponse> GetByIdAsync(Guid id);
}
