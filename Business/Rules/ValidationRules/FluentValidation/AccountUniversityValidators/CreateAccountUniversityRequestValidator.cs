using Business.Dtos.Requests.AccountUniversityRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountUniversityValidators
{
    public class CreateAccountUniversityRequestValidator : AbstractValidator<CreateAccountUniversityRequest>
    {
        public CreateAccountUniversityRequestValidator()
        {
            RuleFor(au => au.StartDate).NotEmpty();
            RuleFor(au => au.StartDate).LessThan(au => au.EndDate);
            RuleFor(au => au.IsEducationActive).NotEmpty();
        }
    }
}
