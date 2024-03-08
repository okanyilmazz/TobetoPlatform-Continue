using Business.Dtos.Requests.UniversityDepartmentRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UniversityDepartmentValidators
{
    public class CreateUniversityDepartmentRequestValidator : AbstractValidator<CreateUniversityDepartmentRequest>
    {
        public CreateUniversityDepartmentRequestValidator()
        {
            RuleFor(u => u.Name).NotEmpty();

        }
    }
}
