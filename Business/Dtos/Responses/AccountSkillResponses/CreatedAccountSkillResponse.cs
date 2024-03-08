namespace Business.Dtos.Responses.AccountSkillResponses;

public class CreatedAccountSkillResponse
{
    public Guid Id { get; set; }
    public Guid SkillId { get; set; }
    public Guid AccountId { get; set; }
}
