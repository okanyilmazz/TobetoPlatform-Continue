namespace Business.Dtos.Requests.AccountOccupationClassRequests
{
    public class UpdateAccountOccupationClassRequest
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public Guid AccountId { get; set; }
    }
}