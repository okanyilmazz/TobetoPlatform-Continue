using Business.Dtos.Requests.AccountHomeworkRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.AccountHomeworkValidators
{
    public class UpdateAccountHomeworkRequestValidator : AbstractValidator<UpdateAccountHomeworkRequest>
    {
        public UpdateAccountHomeworkRequestValidator()
        {
            RuleFor(ah => ah.Status).NotEmpty();
        }
    }
}
