using Business.Dtos.Requests.AnnouncementTypeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementTypeValidators;

public class CreateAnnouncementTypeRequestValidator : AbstractValidator<CreateAnnouncementTypeRequest>
{
    public CreateAnnouncementTypeRequestValidator()
    {
        RuleFor(epl => epl.Name).NotEmpty();
    }
}
