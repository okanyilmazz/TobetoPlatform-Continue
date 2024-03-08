using Business.Dtos.Requests.LessonLikeRequests;
using Business.Dtos.Responses.LessonLikeResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface ILessonLikeService
{
    Task<CreatedLessonLikeResponse> AddAsync(CreateLessonLikeRequest createLessonLikeRequest);
    Task<UpdatedLessonLikeResponse> UpdateAsync(UpdateLessonLikeRequest updateLessonLikeRequest);
    Task<DeletedLessonLikeResponse> DeleteAsync(DeleteLessonLikeRequest deleteLessonLikeRequest);
    Task<IPaginate<GetListLessonLikeResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetListLessonLikeResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListLessonLikeResponse>> GetByAccountIdAsync(Guid accountId);
    Task<IPaginate<GetListLessonLikeResponse>> GetByLessonIdAsync(Guid lessonId);
    Task<DeletedLessonLikeResponse> DeleteByAccountIdAndLessonIdAsync(DeleteLessonLikeRequest deleteLessonLikeRequest);

}

