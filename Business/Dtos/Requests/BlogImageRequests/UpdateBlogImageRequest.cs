using Microsoft.AspNetCore.Http;

namespace Business.Dtos.Requests.BlogImageRequests;

public class UpdateBlogImageRequest
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; }
    public IFormFile File { get; set; }
}
