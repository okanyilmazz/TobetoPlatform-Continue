using Business.Dtos.Requests.CityRequests;
using Business.Rules.ValidationRules.FluentValidation.CityValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CityValidators
{
    public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
    {
        public UpdateCityRequestValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
