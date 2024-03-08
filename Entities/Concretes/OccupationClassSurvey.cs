using Core.Entities;

namespace Entities.Concretes;

public class OccupationClassSurvey : Entity<Guid>
{
    public Guid SurveyId { get; set; }
    public Guid OccupationClassId { get; set; }

    public Survey Survey { get; set; }
    public OccupationClass OccupationClass { get; set; }
}
