using Business.Dtos.Requests.BadgeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.BadgeValidators;
public class CreateBadgeRequestsValidator : AbstractValidator<CreateBadgeRequest>
{
    public CreateBadgeRequestsValidator()
    {
        RuleFor(b=> b.Name).NotEmpty();
    }
}
