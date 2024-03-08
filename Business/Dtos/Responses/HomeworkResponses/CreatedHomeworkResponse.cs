namespace Business.Dtos.Responses.HomeworkResponses;

public class CreatedHomeworkResponse
{
    public Guid Id { get; set; }
    public Guid LessonId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
}