using Business.Dtos.Requests.ExamRequests;
using Business.Dtos.Responses.ExamResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamService
{
    Task<CreatedExamResponse> AddAsync(CreateExamRequest createExamRequest);
    Task<UpdatedExamResponse> UpdateAsync(UpdateExamRequest updateExamRequest);
    Task<DeletedExamResponse> DeleteAsync(DeleteExamRequest deleteExamRequest);
    Task<IPaginate<GetListExamResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetExamResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListExamResponse>> GetByAccountIdAsync(Guid accountId, PageRequest pageRequest);
}
