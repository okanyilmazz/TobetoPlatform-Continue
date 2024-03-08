namespace Business.Dtos.Responses.SurveyResponses;

public class DeletedSurveyResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ConnectionLink { get; set; }
}