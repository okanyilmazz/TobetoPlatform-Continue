namespace Business.Dtos.Requests.HomeworkRequests;

public class DeleteHomeworkRequest
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
}