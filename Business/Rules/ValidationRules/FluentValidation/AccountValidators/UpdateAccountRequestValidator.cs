using Business.Dtos.Requests.AccountRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AccountValidators;

public class UpdateAccountRequestValidator : AbstractValidator<UpdateAccountRequest>
{
    public UpdateAccountRequestValidator()
    {
        RuleFor(a => a.PhoneNumber).NotEmpty();
        RuleFor(a => a.PhoneNumber).MinimumLength(10);
        RuleFor(a => a.PhoneNumber).Matches("^[0-9]+$");
        RuleFor(a => a.NationalId).Length(11);
        RuleFor(a => a.BirthDate).NotEmpty();
        RuleFor(a => a.Description).NotEmpty();
        RuleFor(a => a.Description).MinimumLength(10);
    }
}