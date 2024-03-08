using Business.Dtos.Requests.SkillRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.SkillValidators;

public class UpdateSkillRequestValidator : AbstractValidator<UpdateSkillRequest>
{
    public UpdateSkillRequestValidator()
    {
        RuleFor(s => s.Name).NotEmpty();
    }
}
