namespace Business.Dtos.Requests.BlogRequests;
public class CreateBlogRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string ThumbnailPath { get; set; }
}
