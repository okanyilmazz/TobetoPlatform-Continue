using Microsoft.AspNetCore.Http;

namespace Business.Dtos.Requests.MediaNewImageRequests;

public class CreateMediaNewImageRequest
{
    public Guid MediaNewId { get; set; }
    public IFormFile File { get; set; }
}