using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.EducationProgramDevelopmentValidators;

public class CreateEducationProgramDevelopmentRequestValidator : AbstractValidator<CreateEducationProgramDevelopmentRequest>
{
    public CreateEducationProgramDevelopmentRequestValidator()
    {
            RuleFor(epd => epd.Name).NotEmpty();

    }
}
