using Business.Dtos.Requests.QuestionRequests;
using Business.Dtos.Responses.QuestionResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IQuestionService
{
    Task<CreatedQuestionResponse> AddAsync(CreateQuestionRequest createQuestionRequest);
    Task<UpdatedQuestionResponse> UpdateAsync(UpdateQuestionRequest updateQuestionRequest);
    Task<DeletedQuestionResponse> DeleteAsync(DeleteQuestionRequest deleteQuestionRequest);
    Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListQuestionResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListQuestionResponse>> GetByExamIdAsync(Guid examId, PageRequest pageRequest);
}