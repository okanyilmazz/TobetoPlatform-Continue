using Business.Dtos.Requests.ActivityMapRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ActivityMapValidators;

public class UpdateActivityMapRequestValidator : AbstractValidator<UpdateActivityMapRequest>
{
    public UpdateActivityMapRequestValidator()
    {
        RuleFor(a => a.Name).NotEmpty();
    }
}

