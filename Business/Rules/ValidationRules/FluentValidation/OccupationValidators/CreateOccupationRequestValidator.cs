using Entities.Concretes;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationValidators;

public class CreateOccupationRequestValidator:AbstractValidator<Occupation>
{
    public CreateOccupationRequestValidator()
    {
        RuleFor(o => o.Name).NotEmpty();
    }
}
