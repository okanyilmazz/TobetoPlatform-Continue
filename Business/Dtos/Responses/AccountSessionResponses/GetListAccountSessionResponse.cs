namespace Business.Dtos.Responses.AccountSessionResponses;

public class GetListAccountSessionResponse
{
    public Guid Id { get; set; }
    public Guid SessionId { get; set; }
    public Guid AccountId { get; set; }
    public bool Status { get; set; }
}