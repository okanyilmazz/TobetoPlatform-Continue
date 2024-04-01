using Microsoft.AspNetCore.Http;

namespace Business.Dtos.Requests.BlogImageRequests;

public class CreateBlogImageRequest
{
    public Guid BlogId { get; set; }
    public IFormFile File { get; set; }
}
