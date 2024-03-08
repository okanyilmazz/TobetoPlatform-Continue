using Business.Dtos.Requests.AnnouncementProjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementProjectValidators;

public class CreateAnnouncementProjectRequestValidator : AbstractValidator<CreateAnnouncementProjectRequest>
{
    public CreateAnnouncementProjectRequestValidator()
    {
        RuleFor(ap => ap.ProjectId).NotEmpty();
        RuleFor(ap => ap.AnnouncementId).NotEmpty();

    }
}
