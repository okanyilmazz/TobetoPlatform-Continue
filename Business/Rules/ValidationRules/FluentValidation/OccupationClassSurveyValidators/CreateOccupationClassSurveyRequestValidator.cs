using System;
using Business.Dtos.Requests.OccupationClassSurveyRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationClassSurveyValidators
{
    public class CreateOccupationClassSurveyRequestValidator : AbstractValidator<CreateOccupationClassSurveyRequest>
    {
        public CreateOccupationClassSurveyRequestValidator()
        {

        }

    }

}

