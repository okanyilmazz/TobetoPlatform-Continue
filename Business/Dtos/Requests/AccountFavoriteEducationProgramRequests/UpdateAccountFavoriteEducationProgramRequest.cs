namespace Business.Dtos.Requests.AccountViewLessonRequest;

public class UpdateAccountFavoriteEducationProgramRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
}
