namespace Business.Dtos.Responses.BlogImageResponses;

public class CreatedBlogImageResponse
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; }
    public string ImagePath { get; set; }
}
