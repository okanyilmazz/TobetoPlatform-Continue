using Business.Dtos.Requests.AccountEducationProgramRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AccountEducationProgramValidators;

public class UpdateAccountEducationProgramRequestValidator : AbstractValidator<UpdateAccountEducationProgramRequest>
{
    public UpdateAccountEducationProgramRequestValidator()
    {
        RuleFor(ah => ah.StatusPercent).NotEmpty();
    }
}
