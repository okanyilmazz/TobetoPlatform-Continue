using Business.Dtos.Requests.SkillRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.SkillValidators;

public class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequest>
{
    public CreateSkillRequestValidator()
    {
        RuleFor(s => s.Name).NotEmpty();
    }
}
