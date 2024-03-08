using Business.Dtos.Requests.LessonCategoryRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonCategoryValidators;

public class UpdateLessonCategoryRequestValidator : AbstractValidator<UpdateLessonCategoryRequest>
{
    public UpdateLessonCategoryRequestValidator()
    {
        RuleFor(lc => lc.Name).NotEmpty();
    }
}
