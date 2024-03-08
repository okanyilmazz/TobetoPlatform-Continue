namespace Business.Dtos.Requests.OccupationClassSurveyRequests
{
    public class CreateOccupationClassSurveyRequest
    {
        public Guid SurveyId { get; set; }
        public Guid OccupationClassId { get; set; }
    }
}