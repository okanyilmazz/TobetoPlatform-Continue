using Business.Dtos.Requests.LessonLikeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonLikeValidator
{
    public class UpdateLessonLikeRequestValidator : AbstractValidator<UpdateLessonLikeRequest>
    {
        public UpdateLessonLikeRequestValidator()
        {
            RuleFor(epl => epl.Id).NotEmpty();
            RuleFor(epl => epl.LessonId).NotEmpty();
            RuleFor(epl => epl.AccountId).NotEmpty();
        }
    }
}
