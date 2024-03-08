using Business.Dtos.Requests.AnnouncementRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementValidators;

public class UpdateAnnouncementRequestValidator : AbstractValidator<UpdateAnnouncementRequest>
{
    public UpdateAnnouncementRequestValidator()
    {
        RuleFor(a => a.Title).MinimumLength(2);
        RuleFor(a => a.Title).NotEmpty();
        RuleFor(a => a.Description).MinimumLength(10);
        RuleFor(a => a.Description).NotEmpty();
        RuleFor(a => a.AnnouncementDate).NotEmpty();
    }
}
