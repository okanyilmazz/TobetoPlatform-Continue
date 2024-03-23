using Business.Dtos.Requests.ExamOccupationClassRequests;
using Business.Dtos.Responses.ExamOccupationClassResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IExamOccupationClassService
{
    Task<CreatedExamOccupationClassResponse> AddAsync(CreateExamOccupationClassRequest createExamOccupationClassRequest);
    Task<UpdatedExamOccupationClassResponse> UpdateAsync(UpdateExamOccupationClassRequest updateExamOccupationClassRequest);
    Task<DeletedExamOccupationClassResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListExamOccupationClassResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetExamOccupationClassResponse> GetByIdAsync(Guid id);
}
