using Business.Dtos.Requests.ExamResultRequests;
using Business.Dtos.Responses.ExamResultResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamResultService
{
    Task<IPaginate<GetListExamResultResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedExamResultResponse> AddAsync(CreateExamResultRequest createExamResultRequest);
    Task<UpdatedExamResultResponse> UpdateAsync(UpdateExamResultRequest updateExamResultRequest);
    Task<DeletedExamResultResponse> DeleteAsync(Guid id);
    Task<GetExamResultResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListExamResultResponse>> GetByAccountIdAsync(Guid accountId);
}