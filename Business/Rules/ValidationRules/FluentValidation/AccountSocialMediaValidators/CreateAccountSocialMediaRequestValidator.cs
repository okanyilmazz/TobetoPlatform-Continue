using Business.Dtos.Requests.AccountSocialMediaRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountSocialMediaValidators
{
    public class CreateAccountSocialMediaRequestValidator : AbstractValidator<CreateAccountSocialMediaRequest>
    {
        public CreateAccountSocialMediaRequestValidator()
        {
            RuleFor(asm => asm.Url).NotEmpty();
            RuleFor(asm => asm.Url).MaximumLength(255);
        }
    }
}
