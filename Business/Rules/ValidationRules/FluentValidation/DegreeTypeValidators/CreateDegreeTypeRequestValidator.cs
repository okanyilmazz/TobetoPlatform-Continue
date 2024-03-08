using Business.Dtos.Requests.DegreeTypeRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.DegreeTypeValidators
{
    public class CreateDegreeTypeRequestValidator : AbstractValidator<CreateDegreeTypeRequest>
    {
        public CreateDegreeTypeRequestValidator()
        {
            RuleFor(d => d.Name).NotEmpty();

            RuleFor(d => d.Name).MinimumLength(2);

        }
    }
}
