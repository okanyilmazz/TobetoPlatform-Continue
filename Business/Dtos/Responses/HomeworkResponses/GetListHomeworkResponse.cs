namespace Business.Dtos.Responses.HomeworkResponses
{
    public class GetListHomeworkResponse
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}