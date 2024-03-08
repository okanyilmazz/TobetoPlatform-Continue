using Business.Dtos.Requests.AnnouncementReadRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementReadValidators;

public class CreateAnnouncementReadRequestValidator : AbstractValidator<CreateAnnouncementReadRequest>
{
    public CreateAnnouncementReadRequestValidator()
    {
        RuleFor(ar =>ar.AnnouncementId).NotEmpty();
        RuleFor(ar =>ar.AccountId).NotEmpty();
    }
}
