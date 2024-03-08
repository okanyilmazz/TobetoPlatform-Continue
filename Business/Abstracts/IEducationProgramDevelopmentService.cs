using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using Business.Dtos.Responses.EducationProgramDevelopmentResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IEducationProgramDevelopmentService 
{
    Task<CreatedEducationProgramDevelopmentResponse> AddAsync(CreateEducationProgramDevelopmentRequest createEducationProgramDevelopmentRequest);
    Task<UpdatedEducationProgramDevelopmentResponse> UpdateAsync(UpdateEducationProgramDevelopmentRequest updateEducationProgramDevelopmentRequest);
    Task<DeletedEducationProgramDevelopmentResponse> DeleteAsync(DeleteEducationProgramDevelopmentRequest deleteEducationProgramDevelopmentRequest);
    Task<IPaginate<GetListEducationProgramDevelopmentResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListEducationProgramDevelopmentResponse> GetByIdAsync(Guid id);
}