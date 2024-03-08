using Business.Dtos.Requests.ManagementProgramRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ManagementProgramValidators;

public class CreateManagementProgramRequestValidator:AbstractValidator<CreateManagementProgramRequest>
{
    public CreateManagementProgramRequestValidator()
    {
        RuleFor(l => l.Name).NotEmpty();
    }
}
