using Business.Dtos.Requests.SubjectRequests;
using Business.Dtos.Responses.SubjectResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ISubjectService
{
    Task<CreatedSubjectResponse> AddAsync(CreateSubjectRequest createSubjectRequest);
    Task<DeletedSubjectResponse> DeleteAsync(DeleteSubjectRequest deleteSubjectRequest);
    Task<UpdatedSubjectResponse> UpdateAsync(UpdateSubjectRequest updateSubjectRequest);
    Task<IPaginate<GetListSubjectResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetSubjectResponse> GetByIdAsync(Guid id);
}