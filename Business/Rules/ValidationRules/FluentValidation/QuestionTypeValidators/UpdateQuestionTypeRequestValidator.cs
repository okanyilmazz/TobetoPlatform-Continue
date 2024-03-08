using Business.Dtos.Requests.QuestionTypeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.QuestionTypeValidators;

public class UpdateQuestionTypeRequestValidator : AbstractValidator<UpdateQuestionTypeRequest>
{
    public UpdateQuestionTypeRequestValidator()
    {
        RuleFor(qt => qt.Name).NotEmpty();
    }
}