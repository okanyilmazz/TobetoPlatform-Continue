using Business.Dtos.Requests.WorkExperienceResquests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.WorkExperienceValidators
{
    public class CreateWorkExperienceRequestValidator : AbstractValidator<CreateWorkExperienceRequest>
    {
        public CreateWorkExperienceRequestValidator()
        {
            RuleFor(w => w.Industry).NotEmpty();
            RuleFor(w => w.CompanyName).NotEmpty();
            RuleFor(w => w.Department).NotEmpty();
            RuleFor(w => w.Description).NotEmpty();
            RuleFor(w => w.StartDate).NotEmpty();
            RuleFor(w => w.EndDate).NotEmpty();
        }
    }
}