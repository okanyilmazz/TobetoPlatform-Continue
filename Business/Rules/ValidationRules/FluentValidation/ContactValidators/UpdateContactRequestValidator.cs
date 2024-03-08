using Business.Dtos.Requests.ContactRequests;
using Business.Rules.ValidationRules.FluentValidation.ContactValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.ContactValidators
{
    public class UpdateContactRequestValidator : AbstractValidator<UpdateContactRequest>
    {
        public UpdateContactRequestValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Message).NotEmpty();

            RuleFor(c => c.FirstName).MinimumLength(2);
            RuleFor(c => c.LastName).MinimumLength(2);
            RuleFor(c => c.Email).MinimumLength(2);
            RuleFor(c => c.Message).MinimumLength(2);
        }
    }
}
