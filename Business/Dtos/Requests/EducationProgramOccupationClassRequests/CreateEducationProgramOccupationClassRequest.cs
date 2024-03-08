namespace Business.Dtos.Requests.EducationProgramOccupationClassRequests
{
    public class CreateEducationProgramOccupationClassRequest
    {
        public Guid EducationProgramId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}