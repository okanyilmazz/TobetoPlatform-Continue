using Business.Dtos.Requests.ActivityMapRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ActivityMapValidators;

public class CreateActivityMapRequestValidator : AbstractValidator<CreateActivityMapRequest>
{
    public CreateActivityMapRequestValidator()
    {
        RuleFor(a => a.Name).NotEmpty();
    }
}

