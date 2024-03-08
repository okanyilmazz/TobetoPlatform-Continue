using System;
using Business.Dtos.Requests.QuestionTypeRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.QuestionTypeValidators;

public class CreateQuestionTypeRequestValidator : AbstractValidator<CreateQuestionTypeRequest>
{
    public CreateQuestionTypeRequestValidator()
    {
        RuleFor(qt => qt.Name).NotEmpty();

    }

}

