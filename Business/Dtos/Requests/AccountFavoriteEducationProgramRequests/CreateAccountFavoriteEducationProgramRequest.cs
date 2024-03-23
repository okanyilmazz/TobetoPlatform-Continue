namespace Business.Dtos.Requests.AccountFavoriteEducationProgramRequests;

public class CreateAccountFavoriteEducationProgramRequest
{
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
}
