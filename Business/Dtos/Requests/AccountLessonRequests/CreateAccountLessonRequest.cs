namespace Business.Dtos.Requests.AccountLessonRequests
{
    public class CreateAccountLessonRequest
    {
        public Guid LessonId { get; set; }
        public Guid AccountId { get; set; }
        public double StatusPercent { get; set; }
    }
}