namespace Business.Dtos.Requests.OccupationClassSurveyRequests
{
    public class DeleteOccupationClassSurveyRequest
    {
        public Guid Id { get; set; }
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}