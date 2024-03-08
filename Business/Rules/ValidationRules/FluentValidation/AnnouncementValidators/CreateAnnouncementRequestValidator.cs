using Business.Dtos.Requests.AnnouncementRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementValidators
{
    public class CreateAnnouncementRequestValidator : AbstractValidator<CreateAnnouncementRequest>
    {
        public CreateAnnouncementRequestValidator()
        {
            RuleFor(a => a.Title).MinimumLength(2);
            RuleFor(a => a.Title).NotEmpty();
            RuleFor(a => a.Description).MinimumLength(10);
            RuleFor(a => a.Description).NotEmpty();
            RuleFor(a => a.AnnouncementDate).NotEmpty();
        }
    }
}
