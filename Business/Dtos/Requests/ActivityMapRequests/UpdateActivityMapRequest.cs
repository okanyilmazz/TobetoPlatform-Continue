
namespace Business.Dtos.Requests.ActivityMapRequests;

public class UpdateActivityMapRequest
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public DateTime Date { get; set; }
}

