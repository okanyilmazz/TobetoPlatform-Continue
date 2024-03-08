using Business.Dtos.Requests.OccupationClassRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationClassValidators;

public class UpdateOccupationClassRequestValidator : AbstractValidator<UpdateOccupationClassRequest>
{
    public UpdateOccupationClassRequestValidator()
    {
        RuleFor(o => o.Name).NotEmpty();
    }
}
