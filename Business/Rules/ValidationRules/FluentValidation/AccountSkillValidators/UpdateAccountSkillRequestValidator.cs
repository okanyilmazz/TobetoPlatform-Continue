using Business.Dtos.Requests.AccountSkillRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountSkillValidators
{
    public class UpdateAccountSkillRequestValidator : AbstractValidator<UpdateAccountSkillRequest>
    {
        public UpdateAccountSkillRequestValidator()
        {
        }
    }
}
