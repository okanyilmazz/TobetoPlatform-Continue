using Business.Dtos.Requests.LessonCategoryRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.LessonCategoryValidators
{
    public class CreateLessonCategoryRequestValidator : AbstractValidator<CreateLessonCategoryRequest>
    {
        public CreateLessonCategoryRequestValidator()
        {
            RuleFor(lc => lc.Name).NotEmpty();
        }
    }
}
