using Business.Dtos.Requests.EducationProgramLikeRequests;
using Business.Dtos.Responses.EducationProgramLikeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramLikeService
{
    Task<CreatedEducationProgramLikeResponse> AddAsync(CreateEducationProgramLikeRequest createEducationProgramLikeRequest);
    Task<UpdatedEducationProgramLikeResponse> UpdateAsync(UpdateEducationProgramLikeRequest updateEducationProgramLikeRequest);
    Task<DeletedEducationProgramLikeResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListEducationProgramLikeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetEducationProgramLikeResponse> GetByIdAsync(Guid id);
    Task<GetEducationProgramLikeResponse> GetByEducationProgramIdAndAccountIdAsync(Guid educationProgramId, Guid accountId);
    Task<IPaginate<GetListEducationProgramLikeResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListEducationProgramLikeResponse>> GetByEducationProgramIdAsync(Guid educationProgramId);
    Task<DeletedEducationProgramLikeResponse> DeleteByAccountIdAndEducationProgramIdAsync(DeleteEducationProgramLikeRequest deleteEducationProgramLikeRequest);
}