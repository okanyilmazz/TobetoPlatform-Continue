using Business.Dtos.Requests.AccountAnswerRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountAnswerValidators
{
    public class CreateAccountAnswerRequestValidator : AbstractValidator<CreateAccountAnswerRequest>
    {
        public CreateAccountAnswerRequestValidator()
        {
            RuleFor(a => a.GivenAnswer).NotEmpty();
        }
    }
}
