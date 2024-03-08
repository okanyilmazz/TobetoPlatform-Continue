using Business.Dtos.Requests.AccountEducationProgramRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AccountEducationProgramValidators;

public class CreateAccountEducationProgramRequestValidator : AbstractValidator<CreateAccountEducationProgramRequest>
{
    public CreateAccountEducationProgramRequestValidator()
    {
        RuleFor(ah => ah.StatusPercent).NotEmpty();
    }
}
