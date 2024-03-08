using Business.Dtos.Requests.SessionRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.SessionValidators;

public class UpdateSessionRequestValidator : AbstractValidator<UpdateSessionRequest>
{
    public UpdateSessionRequestValidator()
    {
        RuleFor(s => s.StartDate).NotEmpty();
        RuleFor(s => s.EndDate).NotEmpty();
        RuleFor(s => s.StartDate).LessThan(s => s.EndDate);
        RuleFor(s => s.RecordPath).NotEmpty();
    }
}