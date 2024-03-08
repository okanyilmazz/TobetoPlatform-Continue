namespace Business.Dtos.Requests.EducationProgramLikeRequests;

public class DeleteEducationProgramLikeRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
}
