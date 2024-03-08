using Business.Dtos.Requests.LessonLikeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonLikeValidator;

public class CreateLessonLikeRequestValidator:AbstractValidator<CreateLessonLikeRequest>
{
    public CreateLessonLikeRequestValidator()
    {
        RuleFor(epl => epl.LessonId).NotEmpty();
        RuleFor(epl => epl.AccountId).NotEmpty();
    }
}
