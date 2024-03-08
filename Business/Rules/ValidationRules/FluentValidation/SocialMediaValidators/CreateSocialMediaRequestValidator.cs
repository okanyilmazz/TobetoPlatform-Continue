using Business.Dtos.Requests.SocialMediaRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.SocialMediaValidators
{
    public class CreateSocialMediaRequestValidator : AbstractValidator<CreateSocialMediaRequest>
    {
        public CreateSocialMediaRequestValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.IconPath).NotEmpty();
        }
    }
}
