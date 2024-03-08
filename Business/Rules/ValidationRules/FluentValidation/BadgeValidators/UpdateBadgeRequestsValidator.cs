using Business.Dtos.Requests.BadgeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.BadgeValidators;

public class UpdateBadgeRequestsValidator : AbstractValidator<UpdateBadgeRequest>
{
    public UpdateBadgeRequestsValidator()
    {
        RuleFor(b=> b.Name).NotEmpty();
    }
}
