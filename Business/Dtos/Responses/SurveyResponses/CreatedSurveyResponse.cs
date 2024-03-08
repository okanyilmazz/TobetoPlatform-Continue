namespace Business.Dtos.Responses.SurveyResponses;

public class CreatedSurveyResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ConnectionLink { get; set; }
}
