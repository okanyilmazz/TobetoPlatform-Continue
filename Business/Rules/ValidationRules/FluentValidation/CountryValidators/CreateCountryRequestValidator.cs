using Business.Dtos.Requests.CountryRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CountryValidators
{
    public class CreateCountryRequestValidator : AbstractValidator<CreateCountryRequest>
    {
        public CreateCountryRequestValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Name).MinimumLength(2);

        }
    }
}
