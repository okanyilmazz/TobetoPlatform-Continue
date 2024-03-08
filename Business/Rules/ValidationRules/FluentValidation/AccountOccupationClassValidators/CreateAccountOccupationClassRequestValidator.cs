using Business.Dtos.Requests.AccountOccupationClassRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountOccupationClassValidators
{
    public class CreateAccountOccupationClassRequestValidator : AbstractValidator<CreateAccountOccupationClassRequest>
    {
        public CreateAccountOccupationClassRequestValidator()
        {

        }
    }
}
