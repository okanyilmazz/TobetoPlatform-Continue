using Business.Dtos.Requests.UniversityResquests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UniversityValidators
{
    public class UpdateUniversityRequestValidator : AbstractValidator<UpdateUniversityRequest>
    {
        public UpdateUniversityRequestValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
        }
    }
}
