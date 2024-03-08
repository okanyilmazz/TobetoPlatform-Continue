using Business.Dtos.Requests.EducationProgramDevelopmentRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.EducationProgramDevelopmentValidators;

public class UpdateEducationProgramDevelopmentRequestValidator : AbstractValidator<UpdateEducationProgramDevelopmentRequest>
{
    public UpdateEducationProgramDevelopmentRequestValidator()
    {
        RuleFor(epd => epd.Name).NotEmpty();

    }
}
