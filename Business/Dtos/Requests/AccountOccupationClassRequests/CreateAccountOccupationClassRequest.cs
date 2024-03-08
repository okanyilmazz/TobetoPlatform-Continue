namespace Business.Dtos.Requests.AccountOccupationClassRequests
{
    public class CreateAccountOccupationClassRequest
    {
        public Guid OccupationClassId { get; set; }
        public Guid AccountId { get; set; }
    }
}