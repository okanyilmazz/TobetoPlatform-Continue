namespace Business.Dtos.Responses.AccountLanguageResponses;

public class UpdatedAccountLanguageResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid LanguageId { get; set; }
    public Guid LanguageLevelId { get; set; }
}