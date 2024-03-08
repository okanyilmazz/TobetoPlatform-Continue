using Business.Dtos.Requests.AnnouncementProjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementProjectValidators;

public class UpdateAnnouncementProjectRequestValidator : AbstractValidator<UpdateAnnouncementProjectRequest>
{
    public UpdateAnnouncementProjectRequestValidator()
    {
        RuleFor(ap => ap.ProjectId).NotEmpty();
        RuleFor(ap => ap.AnnouncementId).NotEmpty();
    }
}
