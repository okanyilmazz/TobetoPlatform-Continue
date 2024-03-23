using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using Business.Dtos.Responses.EducationProgramDevelopmentResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramDevelopmentService 
{
    Task<CreatedEducationProgramDevelopmentResponse> AddAsync(CreateEducationProgramDevelopmentRequest createEducationProgramDevelopmentRequest);
    Task<UpdatedEducationProgramDevelopmentResponse> UpdateAsync(UpdateEducationProgramDevelopmentRequest updateEducationProgramDevelopmentRequest);
    Task<DeletedEducationProgramDevelopmentResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListEducationProgramDevelopmentResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetEducationProgramDevelopmentResponse> GetByIdAsync(Guid id);
}