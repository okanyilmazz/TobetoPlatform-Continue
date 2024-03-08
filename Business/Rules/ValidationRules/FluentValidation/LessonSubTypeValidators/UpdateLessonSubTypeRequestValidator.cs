using Business.Dtos.Requests.LessonSubTypeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonSubTypeValidators;

public class UpdateLessonSubTypeRequestValidator : AbstractValidator<UpdateLessonSubTypeRequest>
{
    public UpdateLessonSubTypeRequestValidator()
    {
        RuleFor(ls => ls.Name).NotEmpty();
    }
}
