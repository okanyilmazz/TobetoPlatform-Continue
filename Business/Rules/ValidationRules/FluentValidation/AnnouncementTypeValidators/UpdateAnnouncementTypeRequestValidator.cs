using Business.Dtos.Requests.AnnouncementTypeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementTypeValidators;

public class UpdateAnnouncementTypeRequestValidator : AbstractValidator<UpdateAnnouncementTypeRequest>
{
    public UpdateAnnouncementTypeRequestValidator()
    {
        RuleFor(at => at.Name).NotEmpty();

    }
}
