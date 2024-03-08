using Business.Dtos.Requests.AccountSessionRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountSessionValidators
{
    public class UpdateAccountSessionRequestValidator : AbstractValidator<UpdateAccountSessionRequest>
    {
        public UpdateAccountSessionRequestValidator()
        {
            RuleFor(a => a.Status).NotEmpty();
        }
    }
}
