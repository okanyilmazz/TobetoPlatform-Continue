namespace Business.Dtos.Requests.AccountSessionRequests
{
    public class CreateAccountSessionRequest
    {
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}