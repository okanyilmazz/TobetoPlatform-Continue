using Business.Dtos.Requests.OccupationClassRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationClassValidators;

public class CreateOccupationClassRequestValidator : AbstractValidator<CreateOccupationClassRequest>
{
    public CreateOccupationClassRequestValidator()
    {
        RuleFor(o => o.Name).NotEmpty();
    }
}
