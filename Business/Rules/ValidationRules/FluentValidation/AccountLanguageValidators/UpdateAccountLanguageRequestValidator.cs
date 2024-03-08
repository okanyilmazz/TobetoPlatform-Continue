using Business.Dtos.Requests.AccountLanguageRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountLanguageValidators
{
    public class UpdateAccountLanguageRequestValidator : AbstractValidator<UpdateAccountLanguageRequest>
    {
        public UpdateAccountLanguageRequestValidator()
        {
        }
    }
}
