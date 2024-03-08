using Business.Dtos.Requests.CompetenceTestRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CompetenceTestValidators;

public class CreateCompetenceTestRequestValidator : AbstractValidator<CreateCompetenceTestRequest>
{
    public CreateCompetenceTestRequestValidator()
    {
        RuleFor(eppl => eppl.Name).NotEmpty();
        RuleFor(eppl => eppl.Description).NotEmpty();
        RuleFor(eppl => eppl.QuestionCount).NotEmpty();

        RuleFor(eppl => eppl.Name).MinimumLength(2);
        RuleFor(eppl => eppl.Description).MinimumLength(10);
    }
}
