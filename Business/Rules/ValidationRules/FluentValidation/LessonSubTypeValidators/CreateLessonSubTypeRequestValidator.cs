using Business.Dtos.Requests.LessonSubTypeRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.LessonSubTypeValidators
{
    public class CreateLessonSubTypeRequestValidator : AbstractValidator<CreateLessonSubTypeRequest>
    {
        public CreateLessonSubTypeRequestValidator()
        {
            RuleFor(ls => ls.Name).NotEmpty();
        }
    }
}
