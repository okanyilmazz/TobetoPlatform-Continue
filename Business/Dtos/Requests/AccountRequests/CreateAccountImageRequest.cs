using Microsoft.AspNetCore.Http;

namespace Business.Dtos.Requests.AccountRequests;

public class CreateAccountImageRequest
{
    public Guid Id { get; set; }
    public IFormFile File { get; set; }
}
