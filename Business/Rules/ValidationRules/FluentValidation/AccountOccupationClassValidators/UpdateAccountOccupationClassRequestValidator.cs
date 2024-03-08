using Business.Dtos.Requests.AccountOccupationClassRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AccountOccupationClassValidators;

public class UpdateAccountOccupationClassRequestValidator : AbstractValidator<UpdateAccountOccupationClassRequest>
{
    public UpdateAccountOccupationClassRequestValidator()
    {
    }
}