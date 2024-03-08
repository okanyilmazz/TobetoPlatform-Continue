using Business.Dtos.Requests.ProgrammingLanguageRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ProgrammingLanguageValidators;

public class UpdateProgrammingLanguageRequestValidator : AbstractValidator<UpdateProgrammingLanguageRequest>
{
    public UpdateProgrammingLanguageRequestValidator()
    {
        RuleFor(pl => pl.Name).NotEmpty();
    }
}