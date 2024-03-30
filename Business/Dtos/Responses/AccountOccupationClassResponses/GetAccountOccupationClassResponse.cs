namespace Business.Dtos.Responses.AccountOccupationClassResponses;

public class GetAccountOccupationClassResponse
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid OccupationClassId { get; set; }
    public string OccupationClassName { get; set; }
    public string AccountName { get; set; }
}