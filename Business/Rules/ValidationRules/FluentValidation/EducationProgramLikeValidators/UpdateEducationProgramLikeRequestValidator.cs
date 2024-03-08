using Business.Dtos.Requests.EducationProgramLikeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.EducationProgramLikeValidators;

public class UpdateEducationProgramLikeRequestValidator : AbstractValidator<UpdateEducationProgramLikeRequest>
{
    public UpdateEducationProgramLikeRequestValidator()
    {
        RuleFor(epl => epl.Id).NotEmpty();
        RuleFor(epl => epl.EducationProgramId).NotEmpty();
        RuleFor(epl => epl.AccountId).NotEmpty();
    }
}