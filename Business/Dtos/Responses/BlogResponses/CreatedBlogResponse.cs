namespace Business.Dtos.Responses.BlogResponses;

public class CreatedBlogResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}