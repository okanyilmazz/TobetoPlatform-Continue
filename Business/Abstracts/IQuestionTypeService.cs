using Business.Dtos.Requests.QuestionTypeRequests;
using Business.Dtos.Responses.QuestionTypeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IQuestionTypeService
{
    Task<IPaginate<GetListQuestionTypeResponse>> GetListAsync(PageRequest pageRequest);
    Task<CreatedQuestionTypeResponse> AddAsync(CreateQuestionTypeRequest createQuestionTypeRequest);
    Task<UpdatedQuestionTypeResponse> UpdateAsync(UpdateQuestionTypeRequest updateQuestionTypeRequest);
    Task<DeletedQuestionTypeResponse> DeleteAsync(DeleteQuestionTypeRequest deleteQuestionTypeRequest);
    Task<GetListQuestionTypeResponse> GetByIdAsync(Guid id);
    Task<GetListQuestionTypeResponse> GetByQuestionIdAsync(Guid questionId);
    Task<GetListQuestionTypeNameResponse> GetByExamIdAsync(Guid examId, PageRequest pageRequest);

}