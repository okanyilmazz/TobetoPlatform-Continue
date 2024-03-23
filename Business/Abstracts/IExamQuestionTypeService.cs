using Business.Dtos.Requests.ExamQuestionTypeRequests;
using Business.Dtos.Responses.ExamQuestionTypeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamQuestionTypeService
{
    Task<IPaginate<GetListExamQuestionTypeResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedExamQuestionTypeResponse> AddAsync(CreateExamQuestionTypeRequest createExamQuestionTypeRequest);
    Task<UpdatedExamQuestionTypeResponse> UpdateAsync(UpdateExamQuestionTypeRequest updateExamQuestionTypeRequest);
    Task<DeletedExamQuestionTypeResponse> DeleteAsync(Guid id);
    Task<GetExamQuestionTypeResponse> GetByIdAsync(Guid id);
}
