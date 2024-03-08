using Business.Dtos.Requests.CountryRequests;
using Business.Rules.ValidationRules.FluentValidation.CountryValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CountryValidators
{
    public class UpdateCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
    {
        public UpdateCountryRequestValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
