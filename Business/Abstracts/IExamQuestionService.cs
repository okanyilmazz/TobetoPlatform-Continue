using Business.Dtos.Requests.ExamQuestionRequests;
using Business.Dtos.Responses.ExamQuestionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamQuestionService
	{
    Task<CreatedExamQuestionResponse> AddAsync(CreateExamQuestionRequest createExamQuestionRequest);
    Task<UpdatedExamQuestionResponse> UpdateAsync(UpdateExamQuestionRequest updateExamQuestionRequest);
    Task<DeletedExamQuestionResponse> DeleteAsync(DeleteExamQuestionRequest deleteExamQuestionRequest);
    Task<IPaginate<GetListExamQuestionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListExamQuestionResponse> GetByIdAsync(Guid id);
}