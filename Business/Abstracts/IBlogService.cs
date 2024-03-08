using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Responses.BlogResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts;

public interface IBlogService
{
    Task<CreatedBlogResponse> AddAsync(CreateBlogRequest createBlogRequest);
    Task<UpdatedBlogResponse> UpdateAsync(UpdateBlogRequest updateBlogRequest);
    Task<DeletedBlogResponse> DeleteAsync(DeleteBlogRequest deleteBlogRequest);
    Task<IPaginate<GetListBlogResponse>> GetListAsync(PageRequest pageRequest);
    Task<GetBlogResponse> GetByIdAsync(Guid Id);
}
