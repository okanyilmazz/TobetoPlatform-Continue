namespace Business.Dtos.Requests.AccountFavoriteEducationProgramRequests;

public class UpdateAccountFavoriteEducationProgramRequest
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public Guid EducationProgramId { get; set; }
}
