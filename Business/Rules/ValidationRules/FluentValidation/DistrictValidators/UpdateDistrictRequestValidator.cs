using Business.Dtos.Requests.DistrictRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.DistrictValidators
{
    public class UpdateDistrictRequestValidator : AbstractValidator<UpdateDistrictRequest>
    {
        public UpdateDistrictRequestValidator()
        {
            RuleFor(d => d.Name).NotEmpty();

            RuleFor(d => d.Name).MinimumLength(2);
        }
    }
}
