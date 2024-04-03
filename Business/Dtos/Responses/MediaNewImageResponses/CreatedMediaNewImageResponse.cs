namespace Business.Dtos.Responses.MediaNewImageResponses;

public class CreatedMediaNewImageResponse
{
    public Guid Id { get; set; }
    public Guid MediaNewId { get; set; }
    public string ImagePath { get; set; }
}
