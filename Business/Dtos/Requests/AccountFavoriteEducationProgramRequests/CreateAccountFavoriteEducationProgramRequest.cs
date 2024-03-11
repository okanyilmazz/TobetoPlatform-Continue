namespace Business.Dtos.Requests.AccountViewLessonRequest;

public class CreateAccountFavoriteEducationProgramRequest
{
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
}
