using Business.Dtos.Requests.AccountLessonRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountLessonValidators
{
    public class UpdateAccountLessonRequestValidator : AbstractValidator<UpdateAccountLessonRequest>
    {
        public UpdateAccountLessonRequestValidator()
        {
        }
    }
}
