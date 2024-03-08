using Business.Dtos.Requests.EducationProgramLikeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.EducationProgramLikeValidators;

public class CreateEducationProgramLikeRequestValidator : AbstractValidator<CreateEducationProgramLikeRequest>
{
    public CreateEducationProgramLikeRequestValidator()
    {
        RuleFor(epl => epl.EducationProgramId).NotEmpty();
        RuleFor(epl => epl.AccountId).NotEmpty();
    }
}