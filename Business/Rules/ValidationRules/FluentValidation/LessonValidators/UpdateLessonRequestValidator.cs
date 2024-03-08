using Business.Dtos.Requests.LessonRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.LessonValidators
{
    public class UpdateLessonRequestValidator : AbstractValidator<UpdateLessonRequest>
    {
        public UpdateLessonRequestValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.StartDate).NotEmpty();
            RuleFor(l => l.EndDate).NotEmpty();
            RuleFor(l => l.Duration).NotEmpty();
        }
    }
}
