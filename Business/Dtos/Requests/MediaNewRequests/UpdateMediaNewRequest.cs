namespace Business.Dtos.Requests.MediaNewRequests;

public class UpdateMediaNewRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
}