using Business.Dtos.Requests.BlogImageRequests;
using Business.Dtos.Responses.BlogImageResponses;
using Business.Dtos.Responses.BlogResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IBlogImageService
{
    Task<UpdatedBlogImageResponse> UpdateAsync(UpdateBlogImageRequest updateBlogImageRequest);
    Task<CreatedBlogImageResponse> AddAsync(CreateBlogImageRequest createBlogImageRequest, string currentPath);
    Task<DeletedBlogImageResponse> DeleteAsync(Guid id);
    Task<IPaginate<GetListBlogImageResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetBlogImageResponse> GetByIdAsync(Guid id);
    Task<GetBlogImageResponse> GetByBlogIdAsync(Guid blogId);
}
