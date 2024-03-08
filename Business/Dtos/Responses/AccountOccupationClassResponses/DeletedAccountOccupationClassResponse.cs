namespace Business.Dtos.Responses.AccountOccupationClassResponses;

public class DeletedAccountOccupationClassResponse
{
    public Guid Id { get; set; }
    public Guid OccupationClassId { get; set; }
    public Guid AccountId { get; set; }
}