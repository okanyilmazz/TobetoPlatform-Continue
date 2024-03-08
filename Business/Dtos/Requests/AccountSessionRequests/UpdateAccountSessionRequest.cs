namespace Business.Dtos.Requests.AccountSessionRequests
{
    public class UpdateAccountSessionRequest
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid AccountId { get; set; }
        public bool Status { get; set; }
    }
}