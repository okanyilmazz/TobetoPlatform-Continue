namespace Business.Dtos.Responses.AccountOccupationClassResponses;

public class CreatedAccountOccupationClassResponse
{
    public Guid Id { get; set; }
    public Guid OccupationClassId { get; set; }
    public Guid AccountId { get; set; }
}