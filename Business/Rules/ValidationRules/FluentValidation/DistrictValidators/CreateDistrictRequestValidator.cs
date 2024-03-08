using Business.Dtos.Requests.DistrictRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.DistrictValidators
{
    public class CreateDistrictRequestValidator : AbstractValidator<CreateDistrictRequest>
    {
        public CreateDistrictRequestValidator()
        {
            RuleFor(d => d.Name).NotEmpty();

            RuleFor(d => d.Name).MinimumLength(2);
        }
    }
}
