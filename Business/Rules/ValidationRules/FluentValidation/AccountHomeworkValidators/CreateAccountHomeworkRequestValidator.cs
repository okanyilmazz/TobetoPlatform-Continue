using Business.Dtos.Requests.AccountHomeworkRequests;
using FluentValidation;
namespace Business.Rules.ValidationRules.FluentValidation.AccountHomeworkValidators;

public class CreateAccountHomeworkRequestValidator : AbstractValidator<CreateAccountHomeworkRequest>
{
    public CreateAccountHomeworkRequestValidator()
    {
        RuleFor(ah => ah.Status).NotEmpty();
    }
}
