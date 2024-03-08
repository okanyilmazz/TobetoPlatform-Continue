using Entities.Concretes;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationValidators;

public class UpdateOccupationRequestValidator:AbstractValidator<Occupation>
{
    public UpdateOccupationRequestValidator()
    {
        RuleFor(o => o.Name).NotEmpty();
    }
}
