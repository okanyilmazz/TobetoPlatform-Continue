using Business.Dtos.Requests.UniversityDepartmentRequests;
using Business.Dtos.Responses.UniversityDepartmentResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IUniversityDepartmentService
{
    Task<IPaginate<GetListUniversityDepartmentResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedUniversityDepartmentResponse> AddAsync(CreateUniversityDepartmentRequest createUniversityDepartmentRequest);
    Task<UpdatedUniversityDepartmentResponse> UpdateAsync(UpdateUniversityDepartmentRequest updateUniversityDepartmentRequest);
    Task<DeletedUniversityDepartmentResponse> DeleteAsync(DeleteUniversityDepartmentRequest deleteUniversityDepartmentRequest);
    Task<GetListUniversityDepartmentResponse> GetByIdAsync(Guid id);
}