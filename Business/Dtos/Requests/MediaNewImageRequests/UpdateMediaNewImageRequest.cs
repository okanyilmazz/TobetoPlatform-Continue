using Microsoft.AspNetCore.Http;

namespace Business.Dtos.Requests.MediaNewImageRequests;

public class UpdateMediaNewImageRequest
{
    public Guid Id { get; set; }
    public Guid MediaNewId { get; set; }
    public IFormFile File { get; set; }
}