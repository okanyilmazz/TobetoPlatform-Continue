using Business.Dtos.Requests.OccupationClassSurveyRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationClassSurveyValidators;

public class UpdateOccupationClassSurveyRequestValidator : AbstractValidator<UpdateOccupationClassSurveyRequest>
{
    public UpdateOccupationClassSurveyRequestValidator()
    {
    }
}